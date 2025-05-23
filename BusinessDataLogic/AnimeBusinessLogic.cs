using AccountFrame;
using DataLogic;

namespace BusinessLogic
{
    public class AnimeBusinessLogic
    {
        AnimeDataLogic dataLogic = new AnimeDataLogic();

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName)
        {
            return dataLogic.GetUserAnimeList(UserName);
        }

        public AnimeListFrame.AnimeList GetAnimeByName(Accounts UserName, string AnimeName)
        {
            foreach (var anime in UserName.AnimeList)
            {
                if (anime.Name.Equals(AnimeName, StringComparison.OrdinalIgnoreCase))
                {
                    return anime;
                }
            }
            return null;
        }

        public List<AnimeListFrame.AnimeList> GetAnimeByGenre(Accounts UserName, string AnimeGenre)
        {
            List<AnimeListFrame.AnimeList> AnimeByGenreList = new List<AnimeListFrame.AnimeList>();

            foreach (var anime in UserName.AnimeList)
            {
                if (anime.Genre.Equals(AnimeGenre, StringComparison.OrdinalIgnoreCase))
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

            foreach (var anime in UserName.AnimeList)
            {
                if (anime.ReleaseYear.Equals(ReleaseYear, StringComparison.OrdinalIgnoreCase))
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

        public static int GetAnimeIndex(Accounts UserName, string AnimeName)
        {
            for (int i = 0; i < UserName.AnimeList.Count; i++)
            {
                if (UserName.AnimeList[i].Name.Equals(AnimeName, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool GetAnimeStatusIsWatched(Accounts UserName, int AnimeNameIndex)
        {
            return UserName.AnimeList[AnimeNameIndex].IsWatched;
        }

        public List<AnimeListFrame.AnimeList> GetAnimeToWatchedList(Accounts UserName)
        {        
            List<AnimeListFrame.AnimeList> AnimeWatchedList = new List<AnimeListFrame.AnimeList>();

            foreach (var anime in UserName.AnimeList)
            {
                if (!anime.IsWatched)
                {
                    AnimeWatchedList.Add(anime);
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
                    
        public List<AnimeListFrame.AnimeList> GetAnimeWatchedList(Accounts UserName)
        {        
            List<AnimeListFrame.AnimeList> AnimeToWatchedList = new List<AnimeListFrame.AnimeList>();

            foreach (var anime in UserName.AnimeList)
            {
                if (anime.IsWatched)
                {
                    AnimeToWatchedList.Add(anime);
                }
            }

            if(AnimeToWatchedList.Count == 0)
            {
                return null;
            }
            else
            {
                return AnimeToWatchedList;
            }
        }

        public void AddAnime(Accounts UserName, string AnimeName, string Genre, string ReleaseDate)
        {
            dataLogic.AddAnime(UserName, AnimeName, Genre, ReleaseDate);
        }

        public void DeleteAnime(Accounts account, int AnimeNameIndex)
        {
            dataLogic.DeleteAnime(account, AnimeNameIndex);
        }

        public void MarkAnimeAsWatched(Accounts UserName, int AnimeName, string formattedDate, string Rate)
        {
            dataLogic.MarkAnimeAsWatched(UserName, AnimeName, formattedDate, Rate);
        }

        public Accounts ValidateAccount(string UserName, string Password)
        {
            dataLogic.GetAnimeAccount();

            foreach (var account in dataLogic.GetAnimeAccount())
            {
                if (account.UserName == UserName && account.Password == Password)
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
