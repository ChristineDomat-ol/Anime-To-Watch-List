using AccountFrame;
using DataLogic;

namespace BusinessLogic
{
    public class AnimeBusinessLogic
    {
        AnimeDataLogic dataLogic = new AnimeDataLogic();

        public List<Accounts> GetAnimeAccounts()
        {
            return dataLogic.AnimeAccount;
        }

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName)
        {
            return dataLogic.GetUserAnimeList(UserName);
        }

        public static bool IsAnimeInList(Accounts UserName, string AnimeName)
        {
            foreach (var anime in UserName.AnimeList)
            {
                if (anime.Name == AnimeName)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddAnime(Accounts UserName, string AnimeName, string Genre, string ReleaseDate)
        {
            dataLogic.AddAnime(UserName, AnimeName, Genre, ReleaseDate);
        }

        public void DeleteAnime(Accounts UserName, string AnimeName)
        {
            dataLogic.DeleteAnime(UserName, AnimeName);
        }

        public void MarkAnimeAsWatched(Accounts UserName, string AnimeName)
        {
            dataLogic.MarkAnimeAsWatched(UserName, AnimeName);
        }

        public bool IsAnimeListEmpty(Accounts user)
        {
            var list = dataLogic.GetUserAnimeList(user);
            return list.Count == 0;
        }

        public Accounts ValidateAccount(string UserName, string Password)
        {
            return dataLogic.ValidateAccount(UserName, Password);
        }

        public void AddAccount(string Name, string UserName, string Password)
        {
            dataLogic.AddAccount(Name, UserName, Password);
        }

        public bool IsAccountExists(string UserName)
        {
            return dataLogic.IsAccountExists(UserName);
        }
    }
}
