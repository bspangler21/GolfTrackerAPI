using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GolfTrackerAPI.Models
{
    public class Matches
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("leagueId")]
        public string leagueId { get; set; } = null!;

        [BsonElement("dateId")]
        public string dateId { get; set; } = null!;

        [BsonElement("golfer1Id")]
        public string golfer1Id { get; set; } = null!;

        [BsonElement("golfer2Id")]
        public string golfer2Id { get; set; } = null!;
    }
}
