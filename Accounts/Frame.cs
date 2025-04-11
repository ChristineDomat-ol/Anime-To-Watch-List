using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprints
{
    public class Frame
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Anime> AnimeList { get; set; } = new List<Anime>();
    }


    public class Anime
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public bool IsWatched { get; set; } = false;

    }
}
