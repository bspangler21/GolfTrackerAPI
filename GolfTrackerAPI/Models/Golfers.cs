using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GolfTrackerAPI.Models
{
    public class Golfers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("FirstName")]
        public string firstName { get; set; } = null!;

        [BsonElement("LastName")]
        public string lastName { get; set; } = null!;

        [BsonElement("Handicap")]
        public int handicap { get; set; } = 0;

    }
}
