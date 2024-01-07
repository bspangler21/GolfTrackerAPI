using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GolfTrackerAPI.Models
{
    public class Dates
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("leagueId")]
        public string leagueId { get; set; } = null!;

        [BsonElement("matchDate")]
        public DateTime matchDate { get; set; } = DateTime.Now;

        [BsonElement("matchWeekNumber")]
        public int matchWeekNumber { get; set; } = 0;

    }
}
