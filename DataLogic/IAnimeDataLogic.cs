using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountFrame;

namespace DataLogic
{
    public interface IAnimeDataLogic
    {
        public List<Accounts> GetAnimeAccount();
        public void AddAccount(Accounts accounts);
        public void DeleteAccount(Accounts account);
        public void AddAnime(Accounts Username, string AnimeName, string Genre, string ReleaseDate);
        public void DeleteAnime(Accounts UserName, int AnimeNameIndex);
        public void MarkAnimeAsWatched(Accounts UserName, int AnimeName, string formattedDate, string Rate);
        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName);
    }
}
