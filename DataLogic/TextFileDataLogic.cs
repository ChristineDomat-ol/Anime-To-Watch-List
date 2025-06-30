using AccountFrame;
using AnimeListFrame;

namespace DataLogic
{
    public class TextFileDataLogic : IAnimeDataLogic
    {
        string accountsFilePath = "accounts.txt";
        string animeListFilePath = "animeList.txt";

        List<Accounts> AnimeAccount = new List<Accounts>();

        public TextFileDataLogic()
        {
            GetAccountDataFromFile();
        }

        public List<Accounts> GetAccounts()
        {
            return AnimeAccount;
        }

        public void GetAccountDataFromFile()
        {
            AnimeAccount.Clear();

            var lines = File.ReadAllLines(accountsFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                AnimeAccount.Add(new Accounts
                {
                    AccountID = int.Parse(parts[0]),
                    Name = parts[1],
                    Email = parts[2],
                    Password = parts[3]
                });
            }

            GetAnimeListDataFromFile();
        }

        public void AddAccount(Accounts accounts)
        {
            int accCount = AnimeAccount.Count;  

            AnimeAccount.Add(accounts);

            var newLine = $"\n{accCount+1}|{accounts.Name}|{accounts.Email}|{accounts.Password}";

            File.AppendAllText(accountsFilePath, newLine);

            GetAccountDataFromFile();
        }

        public void DeleteAccount(Accounts account)
        {
            int index = -1;
            for (int i = 0; i < AnimeAccount.Count; i++)
            {
                if (AnimeAccount[i].Email == account.Email && AnimeAccount[i].Password == account.Password)
                {
                    index = i;
                }
            }
            AnimeAccount.RemoveAt(index);

            WriteAccountDataToFile();
            GetAccountDataFromFile();
        }

        private void WriteAccountDataToFile()
        {
            var lines = new string[AnimeAccount.Count];

            for (int i = 0; i < AnimeAccount.Count; i++)
            {
                lines[i] = $"{AnimeAccount[i].AccountID}|{AnimeAccount[i].Name}|{AnimeAccount[i].Email}|{AnimeAccount[i].Password}";
            }

            File.WriteAllLines(accountsFilePath, lines);
        }

        public void AddAnime(AnimeList animeList)
        {
            Accounts Username = null;

            foreach (var account in AnimeAccount)
            {
                if (account.AccountID == animeList.AccountID)
                {
                    Username = account;
                    break; 
                }
            }

            Username.AnimeList.Add(new AnimeListFrame.AnimeList
            {
                Name = animeList.Name,
                Genre = animeList.Genre,
                ReleaseYear = animeList.ReleaseYear
            });

            var newLine = $"\n{Username.Email}|{animeList.Name}|{animeList.Genre}|{animeList.ReleaseYear}|False| |";

            File.AppendAllText(animeListFilePath, newLine);

            GetAnimeListDataFromFile();
        }

        public void DeleteAnime(AnimeList animeList)
        {
            Accounts accounts = null;

            foreach (var account in AnimeAccount)
            {
                if (account.AccountID == animeList.AccountID)
                {
                    accounts = account;
                    break;
                }
            }

            int animeIndex = -1;

            for (int i = 0; i < accounts.AnimeList.Count; i++)
            {
                if (accounts.AnimeList[i].Name.Equals(animeList.Name, StringComparison.OrdinalIgnoreCase) &&
                    accounts.AnimeList[i].AccountID == animeList.AccountID)
                {
                    animeIndex = i;
                    break;
                }
            }

            if (animeIndex != -1)
            {
                accounts.AnimeList.RemoveAt(animeIndex);
                WriteAnimeListDataToFile();
                GetAnimeListDataFromFile();
                Console.WriteLine("Anime deleted successfully.");
            }
            else
            {
                Console.WriteLine("Anime not found in the list.");
            }
        }


        public void MarkAnimeAsWatched(AnimeList animeList)
        {
            Accounts accounts = null;

            foreach (var account in AnimeAccount)
            {
                if (account.AccountID == animeList.AccountID)
                {
                    accounts = account;
                    break;
                }
            }

            accounts.AnimeList[animeList.AnimeID].IsWatched = true;
            accounts.AnimeList[animeList.AnimeID].DateAndTime = animeList.DateAndTime;
            accounts.AnimeList[animeList.AnimeID].Ratings = animeList.Ratings;

            WriteAnimeListDataToFile(accounts);
            GetAnimeListDataFromFile();
        }

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName)
        {
            if (UserName.AnimeList.Count == 0)
            {
                return null;
            }
            return UserName.AnimeList;
        }

        public void GetAnimeListDataFromFile()
        {
            foreach (var account in AnimeAccount)
            {
                account.AnimeList.Clear();
            }

            var lines = File.ReadAllLines(animeListFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                var username = parts[0];

                Accounts account = null;

                foreach (var a in AnimeAccount)
                {
                    if (a.Email == username)
                    {
                        account = a;
                        break;
                    }
                }

                if (account != null)
                {
                    account.AnimeList.Add(new AnimeListFrame.AnimeList
                    {
                        Name = parts[1],
                        Genre = parts[2],
                        ReleaseYear = parts[3],
                        IsWatched = bool.Parse(parts[4]),
                        DateAndTime = parts[5],
                        Ratings = parts[6]
                    });
                }
            }
        }

        private void WriteAnimeListDataToFile(Accounts accounts)
        {
            var lines = new string[accounts.AnimeList.Count];
            int index = 0;

            foreach (var anime in accounts.AnimeList)
            {
                string line = $"{accounts.Email}|{anime.Name}|{anime.Genre}|{anime.ReleaseYear}|{anime.IsWatched}|{anime.DateAndTime}|{anime.Ratings}";
                lines[index] = line;
                index++;
            }

            File.WriteAllLines(animeListFilePath, lines);
        }

        public List<AnimeList> GetAllAnimeList()
        {
            List<AnimeList> allAnime = new List<AnimeList>();

            foreach (var account in AnimeAccount)
            {
                allAnime.AddRange(account.AnimeList); 
            }

            return allAnime;
        }

        private void WriteAnimeListDataToFile()
        {
            var lines = new List<string>();

            foreach (var account in AnimeAccount)
            {
                foreach (var anime in account.AnimeList)
                {
                    string line = $"{account.Email}|{anime.Name}|{anime.Genre}|{anime.ReleaseYear}|{anime.IsWatched}|{anime.DateAndTime}|{anime.Ratings}";
                    lines.Add(line);
                }
            }

            File.WriteAllLines(animeListFilePath, lines);
        }

        public void UpdateAccount(Accounts account)
        {
            //implemented this method in WinForms UI, but not in console UI
            throw new NotImplementedException();
        }

        public void UpdateToWatchAnime(AnimeList animeList)
        {
            //implemented this method in WinForms UI, but not in console UI
            throw new NotImplementedException();
        }

        public void UpdateWatchedAnime(AnimeList animeList)
        {
            //implemented this method in WinForms UI, but not in console UI
            throw new NotImplementedException();
        }

        public void MarkAnimeAsUnWatched(AnimeList animeList)
        {
            //implemented this method in WinForms UI, but not in console UI
            throw new NotImplementedException();
        }
    }
}
