using AccountFrame;
using AnimeListFrame;
using DataLogic;

namespace BusinessLogic
{
    public class AnimeBusinessLogic
    {
        static AnimeDataLogic dataLogic = new AnimeDataLogic();

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName)
        {
            return dataLogic.GetUserAnimeList(UserName);
        }

        public List<AnimeListFrame.AnimeList> GetAllAnimeList()
        {
            return dataLogic.GetAllAnimeList();
        }

        public AnimeListFrame.AnimeList GetAnimeByName(Accounts UserName, string AnimeName)
        {

            var anime = GetAllAnimeList();

            foreach (var animeItem in anime)
            {
                if (animeItem.Name.Equals(AnimeName, StringComparison.OrdinalIgnoreCase) && animeItem.UserName.Equals(UserName.UserName))
                {
                    return animeItem;
                }
            }
            return null;
        }

        public List<AnimeListFrame.AnimeList> GetAnimeByGenre(Accounts UserName, string AnimeGenre)
        {
            List<AnimeListFrame.AnimeList> AnimeByGenreList = new List<AnimeListFrame.AnimeList>();

            foreach (var anime in GetAllAnimeList())
            {
                if (anime.Genre.Equals(AnimeGenre, StringComparison.OrdinalIgnoreCase) && anime.UserName.Equals(UserName.UserName))
                {
                    AnimeByGenreList.Add(anime);
                }
            }
            if (AnimeByGenreList.Count == 0)
            {
                return null;
            }
            else
            {
                return AnimeByGenreList;
            }
        }

        public List<AnimeListFrame.AnimeList> GetAnimeByReleaseYear(Accounts UserName, string ReleaseYear)
        {
            List<AnimeListFrame.AnimeList> AnimeByReleaseYearList = new List<AnimeListFrame.AnimeList>();

            foreach (var anime in GetAllAnimeList())
            {
                if (anime.ReleaseYear.Equals(ReleaseYear, StringComparison.OrdinalIgnoreCase) && anime.UserName.Equals(UserName.UserName))
                {
                    AnimeByReleaseYearList.Add(anime);
                }
            }
            if (AnimeByReleaseYearList.Count == 0)
            {
                return null;
            }
            else
            {
                return AnimeByReleaseYearList;
            }
        }

        public bool GetAnimeStatusIsWatched(Accounts UserName, string AnimeName)
        {
            var anime = GetAllAnimeList();

            foreach (var animeEntry in anime)
            {
                if (animeEntry.Name.Equals(AnimeName, StringComparison.OrdinalIgnoreCase) && animeEntry.UserName.Equals(UserName) && animeEntry.IsWatched)
                {
                    return true;
                }
            }
            return false;
        }

        public List<AnimeListFrame.AnimeList> GetAnimeToWatchedList(Accounts UserName)
        {        
            List<AnimeListFrame.AnimeList> AnimeToWatchList = new List<AnimeListFrame.AnimeList>();

            var anime = GetAllAnimeList();

            foreach (var animeEntry in anime)
            {
                if (!animeEntry.IsWatched && animeEntry.UserName.Trim().Equals(UserName.UserName.Trim(), StringComparison.Ordinal))
                {
                    AnimeToWatchList.Add(animeEntry);
                }
            }
            if (AnimeToWatchList.Count == 0)
            {
                return null;
            }
            else
            {
                return AnimeToWatchList;
            }
        }
                    
        public List<AnimeListFrame.AnimeList> GetAnimeWatchedList(Accounts UserName)
        {
            List<AnimeListFrame.AnimeList> AnimeWatchedList = new List<AnimeListFrame.AnimeList>();

            var anime = GetAllAnimeList();

            foreach (var animeEntry in anime)
            {
                if (animeEntry.IsWatched && animeEntry.UserName.Trim().Equals(UserName.UserName.Trim(), StringComparison.Ordinal))
                {
                    AnimeWatchedList.Add(animeEntry);
                }
            }
            if (AnimeWatchedList.Count == 0)
            {
                return null;
            }
            else
            {
                return AnimeWatchedList;
            }
        }

        public void AddAnime(Accounts UserName, string AnimeName, string Genre, string ReleaseDate)
        {
            dataLogic.AddAnime(UserName, AnimeName, Genre, ReleaseDate);
        }

        public void DeleteAnime(Accounts account, string anime)
        {
            dataLogic.DeleteAnime(account, anime);
        }

        public void MarkAnimeAsWatched(Accounts UserName, string AnimeName, string formattedDate, string Rate)
        {
            dataLogic.MarkAnimeAsWatched(UserName, AnimeName, formattedDate, Rate);
        }

        public Accounts ValidateAccount(string userName, string password)
        {
            var accounts = dataLogic.GetAnimeAccounts();

            foreach (var account in accounts)
            {
                if (account.UserName.Trim() == userName.Trim() & account.Password.Trim() == password.Trim())
                {
                    return account;
                }
            }
            return null;
        }

        public void AddAccount(Accounts account)
        {
            dataLogic.AddAccount(account);
        }

        public void DeleteAccount(Accounts account)
        {
            dataLogic.DeleteAccount(account);
        }
    }
}
