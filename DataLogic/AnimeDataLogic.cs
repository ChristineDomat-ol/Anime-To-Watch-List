using AccountFrame;
using AnimeListFrame;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace DataLogic
{
    

    public class AnimeDataLogic
    {
        IAnimeDataLogic animeDataLogic;

        public AnimeDataLogic()
        {
            //animeDataLogic = new TextFileDataLogic();
            //animeDataLogic = new InMemoryDataLogic();
            //animeDataLogic = new JsonFileDataLogic();
            animeDataLogic = new DatabaseDataLogic();
        }

        public List<Accounts> GetAnimeAccounts()
        {
            return animeDataLogic.GetAccounts();
        }

        public void AddAccount(Accounts accounts)
        {
            animeDataLogic.AddAccount(accounts);
        }

        public void DeleteAccount(Accounts account)
        {
            animeDataLogic.DeleteAccount(account);
        }

        public void AddAnime(AnimeList animeList)
        {
            animeDataLogic.AddAnime(animeList);
        }

        public void DeleteAnime(AnimeList animeList)
        {
            animeDataLogic.DeleteAnime(animeList);
        }

        public void UpdateToWatchAnime(AnimeList animeList)
        {
            animeDataLogic.UpdateToWatchAnime(animeList);
        }

        public void UpdateWatchedAnime(AnimeList animeList)
        {
            animeDataLogic.UpdateWatchedAnime(animeList);
        }

        public void MarkAnimeAsWatched(AnimeList animeList)
        {
            animeDataLogic.MarkAnimeAsWatched(animeList);
        }

        public void MarkAnimeAsUnWatched(AnimeList animeList)
        {
            animeDataLogic.MarkAnimeAsUnWatched(animeList);
        }

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName)
        {
            return animeDataLogic.GetUserAnimeList(UserName);
        }

        public List<AnimeList> GetAllAnimeList()
        {
            return animeDataLogic.GetAllAnimeList();
        }
    }
}

