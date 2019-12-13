using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Entities
{
    public class Artist
    {
        [BsonId]
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public double _Id { get; set; }

        [BsonElement("artistname")]
        public string ArtistName { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }
        
        [BsonElement("albums")]
        public List<Album> Albums { get; set; }
    }

    public class Album
    {
        [BsonElement("album")]
        public string album { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }
    }

    public class Address
    {
        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }
    }

}
