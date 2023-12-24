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
        public string FirstName { get; set; } = null!;

        [BsonElement("LastName")]
        public string LastName { get; set; } = null!;

        [BsonElement("Handicap")]
        public int Handicap { get; set; } = 0;

    }
}
