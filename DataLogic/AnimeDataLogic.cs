using Blueprints;

namespace DataLogic
{
    public class AnimeDataLogic
    {
        public List<Frame> AnimeAccount = new List<Frame>();


        public void AddAnime(Frame Username, string AnimeName, string Genre, string ReleaseDate)
        {
            Username.AnimeList.Add(new Anime
            {
                Name = AnimeName,
                Genre = Genre,
                ReleaseYear = ReleaseDate
            });
        }

        public void DeleteAnime(Frame UserName, string AnimeName)
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

        public void MarkAnimeAsWatched(Frame UserName, string AnimeName)
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

        public List<Anime> GetUserAnimeList(Frame UserName)
        {
            return UserName.AnimeList;
        }
       
        public AnimeDataLogic()
        {
            CreateDummyAnimeAccounts();
        }

        private void CreateDummyAnimeAccounts()
        {
            AnimeAccount.Add(new Frame
            {
                Name = "Christine Domat-ol",
                UserName = "tin",
                Password = "1111",
            });

            AnimeAccount.Add(new Frame
            {
                Name = "Roxanne Oliveros",
                UserName = "rox",
                Password = "2222",
            });

            AnimeAccount.Add(new Frame
            {
                Name = "Meagan Enguerra",
                UserName = "megs",
                Password = "3333",
            });

            AnimeAccount.Add(new Frame
            {
                Name = "Jobel Araw",
                UserName = "jobs",
                Password = "4444",
            });
        }

        public void AddAccount(string Name, string UserName, string Password)
        {
            AnimeAccount.Add(new Frame
            {
                Name = Name,
                UserName = UserName,
                Password = Password,
            });
        }

        public Frame ValidateAccount(string Email, string Password)
        {
            foreach (var account in AnimeAccount)
            {
                if (account.UserName == Email && account.Password == Password)
                {
                    return account; 
                }
            }
            return null; 
        }


    }

}

