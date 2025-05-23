using AccountFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class InMemoryDataLogic : IAnimeDataLogic
    {
        List<Accounts> AnimeAccount = new List<Accounts>();

        public InMemoryDataLogic()
        {
            //CreateDummyAnimeAccounts();
            //CreateAnimeList();
        }

        private void CreateDummyAnimeAccounts()
        {
            AnimeAccount.Add(new Accounts
            {
                Name = "Christine Domat-ol",
                UserName = "tin",
                Password = "1111",
            });

            AnimeAccount.Add(new Accounts
            {
                Name = "Roxanne Oliveros",
                UserName = "rox",
                Password = "2222",
            });

            AnimeAccount.Add(new Accounts
            {
                Name = "Meagan Enguerra",
                UserName = "megs",
                Password = "3333",
            });

            AnimeAccount.Add(new Accounts
            {
                Name = "Jobel Araw",
                UserName = "jobs",
                Password = "4444",
            });
        }

        private void CreateAnimeList()
        {
            var tinAccount = AnimeAccount.FirstOrDefault(a => a.UserName == "tin");

            if (tinAccount != null)
            {
                tinAccount.AnimeList.Add(new AnimeListFrame.AnimeList
                {
                    Name = "Hunter",
                    Genre = "Action",
                    ReleaseYear = "1999"
                });
                tinAccount.AnimeList.Add(new AnimeListFrame.AnimeList
                {
                    Name = "Naruto",
                    Genre = "Action",
                    ReleaseYear = "1999"
                });
                tinAccount.AnimeList.Add(new AnimeListFrame.AnimeList
                {
                    Name = "Fairy tail",
                    Genre = "Action",
                    ReleaseYear = "2010"
                });
                tinAccount.AnimeList.Add(new AnimeListFrame.AnimeList
                {
                    Name = "Fruit Basket",
                    Genre = "Romance",
                    ReleaseYear = "1990"
                });
                tinAccount.AnimeList.Add(new AnimeListFrame.AnimeList
                {
                    Name = "Moriarty",
                    Genre = "Detective",
                    ReleaseYear = "2010"
                });
            }
        }

        public List<Accounts> GetAnimeAccount()
        {
            return AnimeAccount;
        }

        public void AddAccount(Accounts account)
        {
            AnimeAccount.Add(new Accounts
            {
                Name = account.Name,
                UserName = account.UserName,
                Password = account.Password,
            });
        }

        public void DeleteAccount(Accounts account)
        {
            int index = -1;
            for (int i = 0; i < AnimeAccount.Count; i++)
            {
                if (AnimeAccount[i].Password == account.Password)
                {
                    index = i;
                }
            }
            AnimeAccount.RemoveAt(index);
        }

        public void AddAnime(Accounts Username, string AnimeName, string Genre, string ReleaseDate)
        {
            Username.AnimeList.Add(new AnimeListFrame.AnimeList
            {
                Name = AnimeName,
                Genre = Genre,
                ReleaseYear = ReleaseDate
            });
        }

        public void DeleteAnime(Accounts UserName, int AnimeNameIndex)
        {
            UserName.AnimeList.RemoveAt(AnimeNameIndex);
        }

        public void MarkAnimeAsWatched(Accounts UserName, int AnimeName, string formattedDate, string Rate)
        {
            UserName.AnimeList[AnimeName].IsWatched = true;
            UserName.AnimeList[AnimeName].DateAndTime = formattedDate;
            UserName.AnimeList[AnimeName].Ratings = Rate;
        }

        public List<AnimeListFrame.AnimeList> GetUserAnimeList(Accounts UserName)
        {
            if (AnimeAccount.Count == 0)
            {
                return null;
            }
            return UserName.AnimeList;
        }

    }
}
