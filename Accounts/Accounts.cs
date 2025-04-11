using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFrame
{
    public class Accounts
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<AnimeListFrame.AnimeList> AnimeList { get; set; } = new List<AnimeListFrame.AnimeList>();
    }
}
