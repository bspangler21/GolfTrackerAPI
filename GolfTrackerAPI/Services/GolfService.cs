using GolfTrackerAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public class GolfService
    {
        private readonly IMongoCollection<Golfers> _golfersCollection;

        public GolfService(IOptions<GolferDatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            _golfersCollection = database.GetCollection<Golfers>(databaseSettings.Value.GolfersCollectionName);
        }

        public async Task<List<Golfers>> GetGolfersAsync()
        {
            //List<Golfers> golfers = new List<Golfers>();

            var golfers = await _golfersCollection.FindAsync(_ => true);
            //golfers = await _golfersCollection!.Find(_ => true).ToListAsync();
            return await golfers.ToListAsync();
        }
    }
}
