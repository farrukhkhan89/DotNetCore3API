using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    public class ArtistDto
    {
        public double Id { get; set; }
        public string ArtistName { get; set; }
        public List<AlbumDto> Albums { get; set; }
        public AddressDto Address { get; set; }
        public string MainCategory { get; set; }
    }

    public class AlbumDto
    {
        public string AlbumName { get; set; }
        public int Albumyear { get; set; }
        public string Genre { get; set; }

    }

    public class AddressDto
    {
        public string Street { get; set; }


        public string City { get; set; }


        public string State { get; set; }


        public string Country { get; set; }
    }
}