using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class TrackGenre
    {
        public int TrackID { get; set; }
        public Track Track { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
