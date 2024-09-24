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

        [BsonElement("firstName")]
        public string firstName { get; set; } = null!;

        [BsonElement("lastName")]
        public string lastName { get; set; } = null!;

        [BsonElement("handicap")]
        public int handicap { get; set; } = 0;

    }
}
