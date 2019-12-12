using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Entities
{
    public class Book  // this is not system generated
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }
        [BsonElement("Prie")]
        public decimal Price { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("Author")]
        public string Author { get; set; }
    }
}
