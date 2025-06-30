using AccountFrame;
using AnimeListFrame;

namespace DataLogic
{
    public class InMemoryDataLogic : IAnimeDataLogic
    {
        List<Accounts> AnimeAccount = new List<Accounts>();
        List<AnimeList> AnimeListCollection = new List<AnimeList>();

        public InMemoryDataLogic()
        {
            CreateDummyAnimeAccounts();
            CreateAnimeList();
        }

        private void CreateDummyAnimeAccounts()
        {
            AnimeAccount.Add(new Accounts
            {
                AccountID = 1,
                Name = "Christine Domat-ol",
                Email = "tin",
                Password = "1111",
            });

            AnimeAccount.Add(new Accounts
            {
                AccountID = 2,
                Name = "Roxanne Oliveros",
                Email = "rox",
                Password = "2222",
            });

            AnimeAccount.Add(new Accounts
            {
                AccountID = 3,
                Name = "Meagan Enguerra",
                Email = "megs",
                Password = "3333",
            });

            AnimeAccount.Add(new Accounts
            {
                AccountID = 4,
                Name = "Jobel Araw",
                Email = "jobs",
                Password = "4444",
            });
        }

        private void CreateAnimeList()
        {
            AnimeListCollection.Add(new AnimeListFrame.AnimeList
            {
                AccountID = 1,
                Name = "Hunter",
                Genre = "Action",
                ReleaseYear = "1999"
            });
            AnimeListCollection.Add(new AnimeListFrame.AnimeList
            {
                AccountID = 1,
                Name = "Naruto",
                Genre = "Action",
                ReleaseYear = "1999"
            });
            AnimeListCollection.Add(new AnimeListFrame.AnimeList
            {
                AccountID = 1,
                Name = "Fairy tail",
                Genre = "Action",
                ReleaseYear = "2010"
            });
            AnimeListCollection.Add(new AnimeListFrame.AnimeList
            {
                AccountID = 1,
                Name = "Fruit Basket",
                Genre = "Romance",
                ReleaseYear = "1990"
            });
            AnimeListCollection.Add(new AnimeListFrame.AnimeList
            {
                AccountID = 1,
                Name = "Moriarty",
                Genre = "Detective",
                ReleaseYear = "2010"
            });
        }

        public List<Accounts> GetAccounts()
        {
            return AnimeAccount;
        }

        public void AddAccount(Accounts account)
        {
            int accCount = AnimeAccount.Count;

            AnimeAccount.Add(new Accounts
            {
                AccountID = accCount + 1,
                Name = account.Name,
                Email = account.Email,
                Password = account.Password,
            });
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
        }

        public void AddAnime(AnimeList animeList)
        {
            AnimeListCollection.Add(new AnimeListFrame.AnimeList
            {
                AccountID = animeList.AccountID,
                Name = animeList.Name,
                Genre = animeList.Genre,
                ReleaseYear = animeList.ReleaseYear
            });
        }

        public void DeleteAnime(AnimeList animeList)
        {
            int AnimeNameIndex = -1;

            for (int i = 0; i < AnimeListCollection.Count; i++)
            {
                if (AnimeListCollection[i].AccountID == animeList.AccountID && AnimeListCollection[i].Name == animeList.Name)
                {
                    AnimeNameIndex = i;
                }
            }
            AnimeListCollection.RemoveAt(AnimeNameIndex);
        }

        public void MarkAnimeAsWatched(AnimeList animeList)
        {
            for (int i = 0; i < AnimeListCollection.Count; i++)
            {
                if (AnimeListCollection[i].AccountID == animeList.AccountID && AnimeListCollection[i].Name.Equals(animeList.Name, StringComparison.OrdinalIgnoreCase))

                {
                    AnimeListCollection[i].IsWatched = true;
                    AnimeListCollection[i].DateAndTime = animeList.DateAndTime;
                    AnimeListCollection[i].Ratings = animeList.Ratings;

                    Console.WriteLine("[DEBUG] Marked as watched: " + AnimeListCollection[i].Name); // ✅ TEMP DEBUG
                    break;
                }
            }
        }

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts accounts)
        {
            List<AnimeListFrame.AnimeList> userAnimeList = new List<AnimeListFrame.AnimeList>();

            foreach (var anime in AnimeListCollection)
            {
                if (anime.AccountID == accounts.AccountID)
                {
                    userAnimeList.Add(anime); 
                }
            }

            return userAnimeList;
        }

        public List<AnimeListFrame.AnimeList> GetAllAnimeList()
        {
            return AnimeListCollection;
        }

        public void UpdateAccount(Accounts account)
        {
            throw new NotImplementedException();
        }

        public void UpdateToWatchAnime(AnimeList animeList)
        {
            throw new NotImplementedException();
        }

        public void UpdateWatchedAnime(AnimeList animeList)
        {
            throw new NotImplementedException();
        }

        public void MarkAnimeAsUnWatched(AnimeList animeList)
        {
            throw new NotImplementedException();
        }
    }
}
