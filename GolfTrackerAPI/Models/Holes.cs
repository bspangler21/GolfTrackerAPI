using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GolfTrackerAPI.Models
{
    public class Holes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("courseId")]
        public string courseId { get; set; } = null!;

        [BsonElement("holeNumber")]
        public int holeNumber { get; set; } = 0;

        [BsonElement("holePar")]
        public int holePar { get; set; } = 0;

        [BsonElement("holeHandicap")]
        public int holeHandicap { get; set; } = 0;

        [BsonElement("holeLength")]
        public int holeLength { get; set; } = 0;



    }
}
