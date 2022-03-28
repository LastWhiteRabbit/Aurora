using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("AlbumCovers")]

    public class PhotoAlbum
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool isMain { get; set; }
        public string PublicId { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}
