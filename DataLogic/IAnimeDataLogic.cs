using AccountFrame;
using AnimeListFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLogic
{
    public interface IAnimeDataLogic
    {
        public List<Accounts> GetAccounts();
        public void AddAccount(Accounts accounts);
        public void DeleteAccount(Accounts account);
        public void AddAnime(AnimeList animeList);
        public void DeleteAnime(AnimeList animeList);
        public void UpdateToWatchAnime(AnimeList animeList);
        public void UpdateWatchedAnime(AnimeList animeList);
        public void MarkAnimeAsWatched(AnimeList animeList);
        public void MarkAnimeAsUnWatched(AnimeList animeList);
        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName);
        public List<AnimeListFrame.AnimeList> GetAllAnimeList();
    }
}
