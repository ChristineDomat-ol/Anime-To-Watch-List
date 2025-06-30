using AccountFrame;
using AnimeListFrame;
using System.Text.Json;

namespace DataLogic
{
    class JsonFileDataLogic : IAnimeDataLogic
    {
        List<Accounts> AnimeAccount = new List<Accounts>();
        string accountsFilePath = "accounts.json";

        public JsonFileDataLogic()
        {
            ReadJsonDataFromFile();
        }

        private void ReadJsonDataFromFile()
        {
            string jsonText = File.ReadAllText(accountsFilePath);
            AnimeAccount = JsonSerializer.Deserialize<List<Accounts>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(AnimeAccount, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(accountsFilePath, jsonString);
        }

        public List<Accounts> GetAccounts()
        {
            return AnimeAccount;
        }

        public void AddAccount(Accounts accounts)
        {
            AnimeAccount.Add(accounts);
            WriteJsonDataToFile();
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

            WriteJsonDataToFile();
            ReadJsonDataFromFile();
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

            WriteJsonDataToFile();
        }

        public void DeleteAnime(AnimeList animeList)
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

            int AnimeNameIndex = -1;
            for (int i = 0; i < Username.AnimeList.Count; i++)
            {
                if (Username.AnimeList[i].Name.Equals(animeList.Name, StringComparison.OrdinalIgnoreCase))
                {
                    AnimeNameIndex = i;
                    break;
                }
            }

            Username.AnimeList.RemoveAt(AnimeNameIndex);
            WriteJsonDataToFile();

        }

        public void MarkAnimeAsWatched(AnimeList animeList)
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

            int animeIndex = -1;
            for (int i = 0; i < Username.AnimeList.Count; i++)
            {
                if (Username.AnimeList[i].Name.Equals(animeList.Name, StringComparison.OrdinalIgnoreCase))
                {
                    animeIndex = i;
                    break;
                }
            }

            Username.AnimeList[animeIndex].IsWatched = true;
            Username.AnimeList[animeIndex].DateAndTime = animeList.DateAndTime;
            Username.AnimeList[animeIndex].Ratings = animeList.Ratings;

            WriteJsonDataToFile();
        }

        public List<AnimeList> GetUserAnimeList(Accounts UserName)
        {
            return UserName.AnimeList;
        }

        public List<AnimeList> GetAllAnimeList()
        {
            List<AnimeList> allAnime = new List<AnimeList>();

            for (int i = 0; i < AnimeAccount.Count; i++)
            {
                for (int j = 0; j < AnimeAccount[i].AnimeList.Count; j++)
                {
                    allAnime.Add(AnimeAccount[i].AnimeList[j]);
                }
            }

            return allAnime;
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
