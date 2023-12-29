using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GolfTrackerAPI.Models
{
    public class Leagues
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; } = null!;

    }
}
