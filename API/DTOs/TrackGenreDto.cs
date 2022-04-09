using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TrackGenreDto
    {
        public int TrackID { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
