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

        public void AddAnime(Frame UserName, string AnimeName, string Genre, string ReleaseDate)
        {
            dataLogic.AddAnime(UserName, AnimeName, Genre, ReleaseDate);
        }

        public void DeleteAnime(Frame UserName, string AnimeName)
        {
            dataLogic.DeleteAnime(UserName, AnimeName);
        }

        public void MarkAnimeAsWatched(Frame UserName, string AnimeName)
        {
            dataLogic.MarkAnimeAsWatched(UserName, AnimeName);
        }

        public bool IsAnimeListEmpty(Frame user)
        {
            var list = dataLogic.GetUserAnimeList(user);
            return list.Count == 0;
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
