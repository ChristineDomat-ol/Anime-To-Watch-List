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

        public void AddAnime(Accounts Username, string AnimeName, string Genre, string ReleaseDate)
        {
            animeDataLogic.AddAnime(Username, AnimeName, Genre, ReleaseDate);
        }

        public void DeleteAnime(Accounts account, string anime)
        {
            animeDataLogic.DeleteAnime(account, anime);
        }

        public void MarkAnimeAsWatched(Accounts UserName, string AnimeName, string formattedDate, string Rate)
        {
            animeDataLogic.MarkAnimeAsWatched(UserName, AnimeName, formattedDate, Rate);
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

