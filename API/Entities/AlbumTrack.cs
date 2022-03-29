using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AlbumTrack
    {
        public int AlbumID { get; set; }
        public Album Album { get; set; }
        public int TrackID { get; set; }
        public Track Track { get; set; }
    }
}
