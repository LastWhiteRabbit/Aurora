using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class PlaylistTrack
    {
        public int PlaylistID { get; set; }
        public Playlist Playlist { get; set; }
        public int TrackID { get; set; }
        public Track Track { get; set; }
    }
}
