using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GolfTrackerAPI.Models
{
    public class MatchScores
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("matchId")]
        public string matchId { get; set; } = null!;

        [BsonElement("golferId")]
        public string golferId { get; set; } = null!;

        [BsonElement("totalScore")]
        public int totalScore { get; set; } = 0;

        [BsonElement("holeScores")]
        public string holeScores { get; set; } = null!;
    }
}
