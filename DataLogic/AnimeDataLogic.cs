using AccountFrame;

namespace DataLogic
{
    public class AnimeDataLogic
    {
        public List<Accounts> AnimeAccount = new List<Accounts>();


        public void AddAnime(Accounts Username, string AnimeName, string Genre, string ReleaseDate)
        {
            Username.AnimeList.Add(new AnimeListFrame.AnimeList
            {
                Name = AnimeName,
                Genre = Genre,
                ReleaseYear = ReleaseDate
            });
        }

        public void DeleteAnime(Accounts UserName, string AnimeName)
        {
            foreach (var anime in UserName.AnimeList)
            {
                if (anime.Name == AnimeName)
                {
                    UserName.AnimeList.Remove(anime);
                    break;
                }
            }
        }

        public void MarkAnimeAsWatched(Accounts UserName, string AnimeName)
        {

            foreach (var anime in UserName.AnimeList)
            {
                if (anime.Name == AnimeName)
                {
                    anime.IsWatched = true;
                    break;
                }
            }
        }

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName)
        {
            return UserName.AnimeList;
        }
       
        public AnimeDataLogic()
        {
            CreateDummyAnimeAccounts();
        }

        private void CreateDummyAnimeAccounts()
        {
            AnimeAccount.Add(new Accounts
            {
                Name = "Christine Domat-ol",
                UserName = "tin",
                Password = "1111",
            });

            AnimeAccount.Add(new Accounts
            {
                Name = "Roxanne Oliveros",
                UserName = "rox",
                Password = "2222",
            });

            AnimeAccount.Add(new Accounts
            {
                Name = "Meagan Enguerra",
                UserName = "megs",
                Password = "3333",
            });

            AnimeAccount.Add(new Accounts
            {
                Name = "Jobel Araw",
                UserName = "jobs",
                Password = "4444",
            });
        }

        public void AddAccount(string Name, string UserName, string Password)
        {
            AnimeAccount.Add(new Accounts
            {
                Name = Name,
                UserName = UserName,
                Password = Password,
            });
        }

        public Accounts ValidateAccount(string UserName, string Password)
        {
            foreach (var account in AnimeAccount)
            {
                if (account.UserName == UserName && account.Password == Password)
                {
                    return account; 
                }
            }
            return null; 
        }
        public bool IsAccountExists(string UserName)
        {
            foreach (var account in AnimeAccount)
            {
                if (account.UserName == UserName)
                {
                    return true;
                }
            }
            return false; 
        }

    }

}

