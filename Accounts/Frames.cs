using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprints
{
    public class Frames
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<string> AnimeList { get; set; } = new List<string>();

    }

    public class Anime
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Episodes { get; set; }
        public string ReleaseDate { get; set; }

    }
}
