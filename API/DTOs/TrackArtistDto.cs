using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TrackArtistDto
    {
        public int TrackID { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
    }
}
