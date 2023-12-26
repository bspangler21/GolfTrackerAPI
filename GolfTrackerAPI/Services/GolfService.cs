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

            var golfers = await _golfersCollection.FindAsync(_ => true);
            
            return await golfers.ToListAsync();
        }

        public async Task<Golfers> GetGolferAsync(string id)
        {
            var golfer = await _golfersCollection.FindAsync(g => g.Id == id);

            return await golfer.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Golfers newGolfer)
        {
            await _golfersCollection.InsertOneAsync(newGolfer);
        }

        public async Task UpdateAsync(string id, Golfers updatedGolfer)
        {
            await _golfersCollection.ReplaceOneAsync(g => g.Id == id, updatedGolfer);
        }

        public async Task DeleteAsync(string id)
        {
            await _golfersCollection.DeleteOneAsync(g => g.Id == id);
        }
    }
}
