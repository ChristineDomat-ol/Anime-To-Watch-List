using AccountFrame;
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
            animeDataLogic = new JsonFileDataLogic();

        }

        public List<Accounts> GetAnimeAccount()
        {
            return animeDataLogic.GetAnimeAccount();
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

        public void DeleteAnime(Accounts account, int AnimeNameIndex)
        {
            animeDataLogic.DeleteAnime(account, AnimeNameIndex);
        }

        public void MarkAnimeAsWatched(Accounts UserName, int AnimeName, string formattedDate, string Rate)
        {
            animeDataLogic.MarkAnimeAsWatched(UserName, AnimeName, formattedDate, Rate);
        }

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName)
        {
            return animeDataLogic.GetUserAnimeList(UserName);
        }
    }
}

