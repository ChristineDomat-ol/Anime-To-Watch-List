using Blueprints;
using DataLogic;

namespace BusinessLogic
{
    public class AnimeBusinessLogic
    {
        AnimeDataLogic dataLogic = new AnimeDataLogic();

        public List<Frame> GetAnimeAccounts()
        {
            return dataLogic.AnimeAccount;
        }

        public List<Anime> GetUserAnimeList(Frame UserName)
        {
            return dataLogic.GetUserAnimeList(UserName);
        }

        public static bool IsAnimeInList(Frame UserName, string AnimeName)
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

        public static void AddAnime(Frame UserName, string AnimeName, string Genre, string ReleaseDate)
        {
            AnimeDataLogic.AddAnime(UserName, AnimeName, Genre, ReleaseDate);
        }

        public static void DeleteAnime(Frame UserName, string AnimeName)
        {
            AnimeDataLogic.DeleteAnime(UserName, AnimeName);
        }

        public static void MarkAnimeAsWatched(Frame UserName, string AnimeName)
        {
            AnimeDataLogic.MarkAnimeAsWatched(UserName, AnimeName);
        }

        public static bool EmptyList(Frame UserName)
        {
            return AnimeDataLogic.EmptyList(UserName);
        }

        public Frame ValidateAccount(string Email, string Password)
        {
            return dataLogic.ValidateAccount(Email, Password);
        }

        public void AddAccount(string Name, string UserName, string Password)
        {
            dataLogic.AddAccount(Name, UserName, Password);
        }

    }
}
