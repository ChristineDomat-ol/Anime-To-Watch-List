using Blueprints;

namespace DataLogic
{
    public class AnimeDataLogic
    {
        public List<Frames> AnimeAccount = new List<Frames>();
        public static Frames LoggedInUser { get; set; }

        public static bool IsAnimeInList(string AnimeName)
        {
            return LoggedInUser.AnimeList.Contains(AnimeName);
        }

        public static void AddAnime(string AnimeName)
        {
            LoggedInUser.AnimeList.Add(AnimeName);
        }

        public static void DeleteAnime(string AnimeName)
        {
            LoggedInUser.AnimeList.Remove(AnimeName);
        }

        public static void MarkAnimeAsWatched(string AnimeName)
        {
            int index = LoggedInUser.AnimeList.IndexOf(AnimeName);
            LoggedInUser.AnimeList[index] = AnimeName + " - Watched";
        }

        public static bool EmptyList()
        {
            if (LoggedInUser == null)
            {
                return true;
            }
            return LoggedInUser.AnimeList.Count == 0;
        }


        public List<string> GetUserAnimeList()
        {
            return LoggedInUser.AnimeList;
        }
       
        public AnimeDataLogic()
        {
            CreateDummyAnimeAccounts();
        }

        private void CreateDummyAnimeAccounts()
        {
            AnimeAccount.Add(new Frames
            {
                Name = "Christine Domat-ol",
                UserName = "tin",
                Password = "1111",
            });

            AnimeAccount.Add(new Frames
            {
                Name = "Roxanne Oliveros",
                UserName = "rox",
                Password = "2222",
            });

            AnimeAccount.Add(new Frames
            {
                Name = "Meagan Enguerra",
                UserName = "megs",
                Password = "3333",
            });

            AnimeAccount.Add(new Frames
            {
                Name = "Jobel Araw",
                UserName = "jobs",
                Password = "4444",
            });
        }

        public void AddAccount(string Name, string UserName, string Password)
        {
            AnimeAccount.Add(new Frames
            {
                Name = Name,
                UserName = UserName,
                Password = Password,
            });
        }

        public bool ValidateAccount(string Email, string Password)
        {
            foreach (var account in AnimeAccount)
            {
                if (account.UserName == Email && account.Password == Password)
                {
                    return true;
                }
            }
            return false;
        }

    }

}

