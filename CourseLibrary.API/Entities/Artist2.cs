using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Entities
{
    public class Artist2
    {
        [BsonId]
        [BsonElement("_id")]
        public double Id { get; set; }

        [BsonElement("artistname")]
        public string ArtistName { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("album2_ids")]
        public List<int> AlbumIds { get; set; }
    }
    public class Album2
    {
        [BsonId]
        [BsonElement("_id")]
        public double Id { get; set; }

        [BsonElement("album")]
        public string Album { get; set; }

        [BsonElement("year")]
        public string Year { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }
    }

}
