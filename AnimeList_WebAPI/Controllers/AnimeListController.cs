using AccountFrame;
using AnimeListFrame;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;

namespace AnimeList_WebAPI.Controllers
{
    [ApiController]
    [Route("animeList/[controller]")]
    public class AnimeListController : ControllerBase
    {
        static AnimeBusinessLogic businessLogic = new AnimeBusinessLogic();

        [HttpGet("UserList")]
        public List<AnimeList> GetUserAnimeList(int accountID)
        {

            Accounts account = new Accounts
            {
                AccountID = accountID
            };

            return businessLogic.GetUserAnimeList(account);
        }

        [HttpGet("AnimeList")]
        public List<AnimeList> GetAllAnimeList()
        {
            return businessLogic.GetAllAnimeList();
        }

        [HttpGet("AnimeByName")]
        public AnimeList GetAnimeByName(int accountID, string AnimeName)
        {
            Accounts account = new Accounts
            {
                AccountID = accountID
            };

            var anime = GetAllAnimeList();

            foreach (var animeItem in anime)
            {
                if (animeItem.Name.Equals(AnimeName, StringComparison.OrdinalIgnoreCase) && Convert.ToInt32(animeItem.AccountID) == account.AccountID)
                {
                    return animeItem;
                }
            }
            return null;
        }

        [HttpGet("AnimeByGenre")]
        public List<AnimeList> GetAnimeByGenre(int accountID, string AnimeGenre)
        {
            Accounts account = new Accounts
            {
                AccountID = accountID
            };

            List<AnimeList> AnimeByGenreList = new List<AnimeList>();

            foreach (var anime in GetAllAnimeList())
            {
                if (anime.Genre.Equals(AnimeGenre, StringComparison.OrdinalIgnoreCase) && anime.AccountID.Equals(account.AccountID))
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

        [HttpGet("AnimeByReleaseYear")]
        public List<AnimeList> GetAnimeByReleaseYear(int accountID, string ReleaseYear)
        {
            Accounts account = new Accounts
            {
                AccountID = accountID
            };

            List<AnimeList> AnimeByReleaseYearList = new List<AnimeList>();

            foreach (var anime in GetAllAnimeList())
            {
                if (anime.ReleaseYear.Equals(ReleaseYear, StringComparison.OrdinalIgnoreCase) && anime.AccountID.Equals(account.AccountID))
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

        [HttpGet("IsWatched")]
        public bool GetAnimeStatusIsWatched(int accountID, int AnimeID)
        {
            var anime = GetUserAnimeList(accountID);

            foreach (var animeEntry in anime)
            {
                if (animeEntry.AnimeID == AnimeID && animeEntry.IsWatched)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpGet("ToWatchList")]
        public List<AnimeList> GetAnimeToWatchedList(int accountID)
        {
            Accounts account = new Accounts
            {
                AccountID = accountID
            };

            List<AnimeList> AnimeToWatchList = new List<AnimeList>();

            var anime = GetAllAnimeList();

            foreach (var animeEntry in anime)
            {
                if (!animeEntry.IsWatched && Convert.ToInt32(animeEntry.AccountID) == account.AccountID)
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

        [HttpGet("WatchedList")]
        public List<AnimeList> GetAnimeWatchedList(int accountID)
        {
            Accounts account = new Accounts
            {
                AccountID = accountID
            };

            var anime = GetAllAnimeList();

            List<AnimeList> watchedAnimeList = new List<AnimeList>();

            foreach (AnimeList animeList in anime)
            {
                if (animeList.IsWatched && animeList.AccountID == account.AccountID)
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

        [HttpPost("AddAnime")]
        public void AddAnime(int accountID, string animeName, string animeGenre, string releaseYear)
        {
            AnimeList animeList = new AnimeList
            {
                AccountID = accountID,
                Name = animeName,
                Genre = animeGenre,
                ReleaseYear = releaseYear
            };

            businessLogic.AddAnime(animeList);
        }

        [HttpDelete("DeleteAnime")]
        public void DeleteAnime(int accountID, int animeID)
        {
            AnimeList animeList = new AnimeList
            {
                AccountID = accountID,
                AnimeID = animeID
            };  

            businessLogic.DeleteAnime(animeList);
        }

        [HttpPatch("UpdateToWatch")]
        public void UpdateToWatchAnime(int animeID, int accountID, string animeName, string animeGenre, string releaseYear)
        {
            AnimeList animeList = new AnimeList
            {
                AccountID = accountID,
                AnimeID = animeID,
                Name = animeName,
                Genre = animeGenre,
                ReleaseYear = releaseYear
            };

            businessLogic.UpdateToWatchAnime(animeList);
        }

        [HttpPatch("UpdateWatched")]
        public void UpdateWatchedAnime(int animeID, int accountID, string animeName, string animeGenre, string releaseYear, string dateAndTime, string ratings)
        {
            AnimeList animeList = new AnimeList
            {
                AccountID = accountID,
                AnimeID = animeID,
                Name = animeName,
                Genre = animeGenre,
                ReleaseYear = releaseYear,
                DateAndTime = dateAndTime,
                Ratings = ratings
            };

            businessLogic.UpdateWatchedAnime(animeList);
        }

        [HttpPatch("MarkAsWatched")]
        public void MarkAnimeAsWatched(int accountID, int animeID, string dateAndTime, string ratings)
        {
            AnimeList animeList = new AnimeList
            {
                AccountID = accountID,
                AnimeID = animeID,
                DateAndTime = dateAndTime,
                Ratings = ratings
            };

            businessLogic.MarkAnimeAsWatched(animeList);
        }

        [HttpPatch("MarkAsUnWatched")]
        public void MarkAnimeAsUnWatched(int accountID, int animeID)
        {
            AnimeList animeList = new AnimeList
            {
                AccountID = accountID,
                AnimeID = animeID
            };

            businessLogic.MarkAnimeAsUnWatched(animeList);
        }

        [HttpGet("ValidateAccount")]
        public Accounts ValidateAccount(string userName, string password)
        {
            var accounts = businessLogic.GetAnimeAccounts();

            foreach (var account in accounts)
            {
                if (account.Email.Trim() == userName.Trim() & account.Password.Trim() == password.Trim())
                {
                    return account;
                }
            }
            return null;
        }

        [HttpPost("AddAccount")]
        public void AddAccount(string name, string email, string password)
        {
            Accounts account = new Accounts
            {
                Name = name,
                Email = email,
                Password = password
            };

            businessLogic.AddAccount(account);
        }

        [HttpDelete("DeleteAccount")]
        public void DeleteAccount(int accountID)
        {
            Accounts account = new Accounts
            {
                AccountID = accountID
            };

            businessLogic.DeleteAccount(account);
        }

        [HttpPatch("UpdateAccount")]
        public void UpdateAccount(int accountID, string name, string email, string password)
        {
            Accounts account = new Accounts
            {
                AccountID = accountID,
                Name = name,
                Email = email,
                Password = password
            };

            businessLogic.UpdateAccount(account);
        }
    }
}
