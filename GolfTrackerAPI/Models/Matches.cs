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

        [BsonElement("weekNumber")]
        public int weekNumber { get; set; } = 0;

        [BsonElement("matchDate")]
        public DateTime matchDate { get; set; } = DateTime.Now;

        [BsonElement("golfer1Id")]
        public string? golfer1Id { get; set; } = null;

        [BsonElement("golfer2Id")]
        public string? golfer2Id { get; set; } = null;
    }
}
