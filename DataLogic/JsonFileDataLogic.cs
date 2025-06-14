//using AccountFrame;
//using AnimeListFrame;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Text.Json;

//namespace DataLogic
//{
//    class JsonFileDataLogic : IAnimeDataLogic
//    {
//        List<Accounts> AnimeAccount = new List<Accounts>();
//        string accountsFilePath = "accounts.json";

//        public JsonFileDataLogic()
//        {
//            ReadJsonDataFromFile();
//        }

//        private void ReadJsonDataFromFile()
//        {
//            string jsonText = File.ReadAllText(accountsFilePath);

//            AnimeAccount = JsonSerializer.Deserialize<List<Accounts>>(jsonText,
//                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
//            );
//        }

//        private void WriteJsonDataToFile()
//        {
//            string jsonString = JsonSerializer.Serialize(AnimeAccount, new JsonSerializerOptions
//            { WriteIndented = true });

//            File.WriteAllText(accountsFilePath, jsonString);
//        }
//        public List<Accounts> GetAccounts()
//        {
//            return AnimeAccount;
//        }

//        public void AddAccount(Accounts accounts)
//        {
//            AnimeAccount.Add(accounts);
//            WriteJsonDataToFile();
//        }
        
//        public void DeleteAccount(Accounts account)
//        {
//            int index = -1;
//            for (int i = 0; i < AnimeAccount.Count; i++)
//            {
//                if (AnimeAccount[i].UserName == account.UserName && AnimeAccount[i].Password == account.Password)
//                {
//                    index = i;
//                }
//            }
//            AnimeAccount.RemoveAt(index);

//            WriteJsonDataToFile();
//            ReadJsonDataFromFile();
//        }


//        public void AddAnime(Accounts Username, string AnimeName, string Genre, string ReleaseDate)
//        {
//            Username.AnimeList.Add(new AnimeListFrame.AnimeList
//            {
//                Name = AnimeName,
//                Genre = Genre,
//                ReleaseYear = ReleaseDate
//            });

//            WriteJsonDataToFile();
//        }

        
//        public void DeleteAnime(Accounts UserName, int AnimeNameIndex)
//        {
//            UserName.AnimeList.RemoveAt(AnimeNameIndex);
//            WriteJsonDataToFile();
//        }

//        public List<AnimeList> GetUserAnimeList(Accounts UserName)
//        {
//            return UserName.AnimeList;
//        }

//        public void MarkAnimeAsWatched(Accounts UserName, int AnimeName, string formattedDate, string Rate)
//        {
//            UserName.AnimeList[AnimeName].IsWatched = true;
//            UserName.AnimeList[AnimeName].DateAndTime = formattedDate;
//            UserName.AnimeList[AnimeName].Ratings = Rate;

//            WriteJsonDataToFile();
//        }

//        public List<AnimeList> GetAllAnimeList(Accounts UserName)
//        {
//            throw new NotImplementedException();
//        }

//        public void DeleteAnime(Accounts UserName, AnimeList anime)
//        {
//            throw new NotImplementedException();
//        }

//        public void DeleteAnime(Accounts UserName, string anime)
//        {
//            throw new NotImplementedException();
//        }

//        public void MarkAnimeAsWatched(Accounts UserName, string AnimeName, string formattedDate, string Rate)
//        {
//            throw new NotImplementedException();
//        }

//        public List<AnimeList> GetAllAnimeList()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
