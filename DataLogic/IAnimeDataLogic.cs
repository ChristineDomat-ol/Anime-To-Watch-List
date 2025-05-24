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
        public void AddAnime(Accounts Username, string AnimeName, string Genre, string ReleaseDate);
        public void DeleteAnime(Accounts UserName, string anime);
        public void MarkAnimeAsWatched(Accounts UserName, string AnimeName, string formattedDate, string Rate);
        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName);
        public List<AnimeListFrame.AnimeList> GetAllAnimeList();
    }
}
