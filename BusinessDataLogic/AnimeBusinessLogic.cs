using AccountFrame;
using AnimeListFrame;
using DataLogic;

namespace BusinessLogic
{
    public class AnimeBusinessLogic
    {
        static AnimeDataLogic dataLogic = new AnimeDataLogic();

        public List<AnimeList> GetUserAnimeList(Accounts UserName)
        {
            return dataLogic.GetUserAnimeList(UserName);
        }

        public List<AnimeList> GetAllAnimeList()
        {
            return dataLogic.GetAllAnimeList();
        }

        public AnimeList GetAnimeByName(Accounts accounts, string AnimeName)
        {
            var anime = GetAllAnimeList();

            foreach (var animeItem in anime)
            {
                if (animeItem.Name.Equals(AnimeName, StringComparison.OrdinalIgnoreCase) && Convert.ToInt32(animeItem.AccountID) == accounts.AccountID)
                {
                    return animeItem;
                }
            }
            return null;
        }

        public List<AnimeList> GetAnimeByGenre(Accounts UserName, string AnimeGenre)
        {
            List<AnimeList> AnimeByGenreList = new List<AnimeList>();

            foreach (var anime in GetAllAnimeList())
            {
                if (anime.Genre.Equals(AnimeGenre, StringComparison.OrdinalIgnoreCase) && anime.AccountID.Equals(UserName.AccountID))
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

        public List<AnimeList> GetAnimeByReleaseYear(Accounts UserName, string ReleaseYear)
        {
            List<AnimeList> AnimeByReleaseYearList = new List<AnimeList>();

            foreach (var anime in GetAllAnimeList())
            {
                if (anime.ReleaseYear.Equals(ReleaseYear, StringComparison.OrdinalIgnoreCase) && anime.AccountID.Equals(UserName.AccountID))
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

        public List<AnimeList> GetAnimeToWatchedList(Accounts accounts)
        {
            List<AnimeList> AnimeToWatchList = new List<AnimeList>();

            var anime = GetAllAnimeList();

            foreach (var animeEntry in anime)
            {
                if (!animeEntry.IsWatched && Convert.ToInt32(animeEntry.AccountID) == accounts.AccountID)
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

        public List<AnimeList> GetAnimeWatchedList(Accounts accounts)
        {
            var anime = GetAllAnimeList();

            List<AnimeList> watchedAnimeList = new List<AnimeList>();

            foreach (AnimeList animeList in anime)
            {
                if (animeList.IsWatched && animeList.AccountID == accounts.AccountID)
                {
                    watchedAnimeList.Add(animeList);
                }
            }

            if (watchedAnimeList.Count != 0)
            {
                return watchedAnimeList;
            }
            else
            {
                return null;
            }
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

        public List<Accounts> GetAnimeAccounts()
        {
            return dataLogic.GetAnimeAccounts();
        }

        public Accounts ValidateAccount(string userName, string password)
        {
            var accounts = GetAnimeAccounts();

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

        public void UpdateAccount(Accounts account)
        {
            dataLogic.UpdateAccount(account);
        }
    }
}
