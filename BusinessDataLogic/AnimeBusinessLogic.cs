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
                if (animeItem.Name.Equals(AnimeName, StringComparison.OrdinalIgnoreCase) && animeItem.Email.Equals(UserName.Email))
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
                if (anime.Genre.Equals(AnimeGenre, StringComparison.OrdinalIgnoreCase) && anime.Email.Equals(UserName.Email))
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
                if (anime.ReleaseYear.Equals(ReleaseYear, StringComparison.OrdinalIgnoreCase) && anime.Email.Equals(UserName.Email))
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

        public bool GetAnimeStatusIsWatched(Accounts account, int AnimeID)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var anime = GetUserAnimeList(account);

            foreach (var animeEntry in anime)
            {
                if (animeEntry.AnimeID == AnimeID && animeEntry.IsWatched)
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
                if (!animeEntry.IsWatched && animeEntry.Email.Trim().Equals(UserName.Email.Trim(), StringComparison.Ordinal))
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
            var anime = GetAllAnimeList();

            List<AnimeList> watchedAnimeList = new List<AnimeList>();

            foreach (AnimeList animeList in anime)
            {
                if (animeList.IsWatched && animeList.Email.Trim() == UserName.Email.Trim())
                {
                    watchedAnimeList.Add(animeList);
                }
            }

            return watchedAnimeList;
        }

        public void AddAnime(AnimeList animeList)
        {
            dataLogic.AddAnime(animeList);
        }

        public void DeleteAnime(AnimeList animeList)
        {
            dataLogic.DeleteAnime(animeList);
        }

        public void UpdateToWatchAnime(AnimeList animeList)
        {
            dataLogic.UpdateToWatchAnime(animeList);
        }

        public void UpdateWatchedAnime(AnimeList animeList)
        {
            dataLogic.UpdateWatchedAnime(animeList);
        }

        public void MarkAnimeAsWatched(AnimeList animeList)
        {
            dataLogic.MarkAnimeAsWatched(animeList);
        }

        public void MarkAnimeAsUnWatched(AnimeList animeList)
        {
            dataLogic.MarkAnimeAsUnWatched(animeList);
        }

        public Accounts ValidateAccount(string userName, string password)
        {
            var accounts = dataLogic.GetAnimeAccounts();

            foreach (var account in accounts)
            {
                if (account.Email.Trim() == userName.Trim() & account.Password.Trim() == password.Trim())
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
