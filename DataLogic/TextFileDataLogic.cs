using AccountFrame;
using AnimeListFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    Name = parts[0],
                    UserName = parts[1],
                    Password = parts[2]
                });
            }

            GetAnimeListDataFromFile();
        }

        public void AddAccount(Accounts accounts)
        {
            AnimeAccount.Add(accounts);

            var newLine = $"\n{accounts.Name}|{accounts.UserName}|{accounts.Password}";

            File.AppendAllText(accountsFilePath, newLine);

            GetAccountDataFromFile();
        }

        public void DeleteAccount(Accounts account)
        {
            int index = -1;
            for (int i = 0; i < AnimeAccount.Count; i++)
            {
                if (AnimeAccount[i].UserName == account.UserName && AnimeAccount[i].Password == account.Password)
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
                lines[i] = $"{AnimeAccount[i].Name}|{AnimeAccount[i].UserName}|{AnimeAccount[i].Password}";
            }

            File.WriteAllLines(accountsFilePath, lines);
        }

        public void AddAnime(Accounts Username, string AnimeName, string Genre, string ReleaseDate)
        {
            Username.AnimeList.Add(new AnimeListFrame.AnimeList
            {
                Name = AnimeName,
                Genre = Genre,
                ReleaseYear = ReleaseDate
            });

            var newLine = $"\n{Username.UserName}|{AnimeName}|{Genre}|{ReleaseDate}|False| |";

            File.AppendAllText(animeListFilePath, newLine);

            GetAnimeListDataFromFile();
        }

        public void DeleteAnime(Accounts accounts, int animeIndex)
        {
            accounts.AnimeList.RemoveAt(animeIndex);
            WriteAnimeListDataToFile(accounts);
            GetAnimeListDataFromFile();
        }

        public void MarkAnimeAsWatched(Accounts accounts, int AnimeName, string formattedDate, string Rate)
        {
            accounts.AnimeList[AnimeName].IsWatched = true;
            accounts.AnimeList[AnimeName].DateAndTime = formattedDate;
            accounts.AnimeList[AnimeName].Ratings = Rate;

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
                    if (a.UserName == username)
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
                string line = $"{accounts.UserName}|{anime.Name}|{anime.Genre}|{anime.ReleaseYear}|{anime.IsWatched}|{anime.DateAndTime}|{anime.Ratings}";
                lines[index] = line;
                index++;
            }

            File.WriteAllLines(animeListFilePath, lines);
        }

        public List<AnimeList> GetAllAnimeList(Accounts UserName)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnime(Accounts UserName, AnimeList anime)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnime(Accounts UserName, string anime)
        {
            throw new NotImplementedException();
        }

        public void MarkAnimeAsWatched(Accounts UserName, string AnimeName, string formattedDate, string Rate)
        {
            throw new NotImplementedException();
        }

        public List<AnimeList> GetAllAnimeList()
        {
            throw new NotImplementedException();
        }

        //private void WriteAnimeListDataToFile()
        //{
        //    var lines = new List<string>();

        //    foreach (var account in AnimeAccount)
        //    {
        //        foreach (var anime in account.AnimeList)
        //        {
        //            string line = $"{account.UserName}|{anime.Name}|{anime.Genre}|{anime.ReleaseYear}|{anime.IsWatched}|{anime.DateAndTime}|{anime.Ratings}";
        //            lines.Add(line);
        //        }
        //    }

        //    File.WriteAllLines(animeListFilePath, lines);
        //}

    }
}
