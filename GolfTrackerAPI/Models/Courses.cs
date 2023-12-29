using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GolfTrackerAPI.Models
{
    public class Courses
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; } = null!;

        [BsonElement("description")]
        public string description { get; set; } = null!;

        [BsonElement("address")]
        public string address { get; set; } = null!;

        [BsonElement("city")]
        public string city { get; set; } = null!;

        [BsonElement("state")]
        public string state { get; set; } = null!;

        [BsonElement("zip")]
        public string zip { get; set; } = null!;

        [BsonElement("holes")]
        public int holes { get; set; } = 0;

        [BsonElement("par")]
        public int par { get; set; } = 0;

    }
}
