using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListFrame
{
    public class AnimeList
    {
        public int AnimeID { get; set; }
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public bool IsWatched { get; set; } = false;
        public string DateAndTime { get; set; }
        public string Ratings { get; set; }

    }
}
