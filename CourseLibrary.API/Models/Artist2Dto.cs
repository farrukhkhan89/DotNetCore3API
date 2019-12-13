using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    public class Artist2Dto
    {
        public double Id { get; set; }
        public string ArtistName { get; set; }
        public List<AlbumDto> Albums { get; set; }
        public AddressDto Address { get; set; }
        public string MainCategory { get; set; }
    }

    public class Album2Dto
    {
        public string AlbumName { get; set; }
        public int Albumyear { get; set; }
        public string Genre { get; set; }

    }
}
