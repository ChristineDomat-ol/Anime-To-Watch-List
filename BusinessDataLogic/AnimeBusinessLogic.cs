using Blueprints;
using DataLogic;

namespace BusinessLogic
{
    public class AnimeBusinessLogic
    {
        AnimeDataLogic dataLogic = new AnimeDataLogic();

        public List<Frames> GetAnimeAccounts()
        {
            return dataLogic.AnimeAccount;
        }

        public List<string> GetUserAnimeList()
        {
            return dataLogic.GetUserAnimeList();
        }

        public static bool IsAnimeInList(string AnimeName)
        {
            return AnimeDataLogic.IsAnimeInList(AnimeName);
        }

        public static void AddAnime(string AnimeName)
        {
            AnimeDataLogic.AddAnime(AnimeName);
        }

        public static void DeleteAnime(string AnimeName)
        {
            AnimeDataLogic.DeleteAnime(AnimeName);
        }

        public static void MarkAnimeAsWatched(string AnimeName)
        {
            AnimeDataLogic.MarkAnimeAsWatched(AnimeName);
        }

        public static bool EmptyList()
        {
            return AnimeDataLogic.EmptyList();
        }

        public bool ValidateAccount(string Email, string Password)
        {
            return dataLogic.ValidateAccount(Email, Password);
        }

        public void AddAccount(string Name, string UserName, string Password)
        {
            dataLogic.AddAccount(Name, UserName, Password);
        }

    }
}
