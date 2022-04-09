using API.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class TrackDto
    {
        [DisplayName("Track name")]
        [Required]
        public string TrackName { get; set; }
        [DisplayName("Track length")]
        public string Length { get; set; }
        public string About { get; set; }
        public ICollection<TrackGenreDto> Genres { get; set; }
        public ICollection<TrackArtistDto> Artists { get; set; }
    }
}
