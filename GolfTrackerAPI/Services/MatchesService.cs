using GolfTrackerAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public class MatchesService
    {
        private readonly IMongoCollection<Matches> _matchesCollection;

        public MatchesService(IOptions<MatchesDatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            _matchesCollection = database.GetCollection<Matches>(databaseSettings.Value.MatchesCollectionName);
        }

        public async Task<List<Matches>> GetMatchesAsync()
        {

            var matches = await _matchesCollection.FindAsync(_ => true);
            
            return await matches.ToListAsync();
        }

        public async Task<Matches> GetMatchAsync(string id)
        {
            var match = await _matchesCollection.FindAsync(m => m.Id == id);

            return await match.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Matches newMatch)
        {
            await _matchesCollection.InsertOneAsync(newMatch);
        }

        public async Task UpdateAsync(string id, Matches updatedMatch)
        {
            FilterDefinition<Matches> filter = Builders<Matches>.Filter.Eq(m => m.Id, id);
            UpdateDefinition<Matches> update = Builders<Matches>.Update
                .Set(m => m.leagueId, updatedMatch.leagueId)
                .Set(m => m.dateId, updatedMatch.dateId)
                .Set(m => m.golfer1Id, updatedMatch.golfer1Id)
                .Set(m => m.golfer2Id, updatedMatch.golfer2Id);
            await _matchesCollection.UpdateOneAsync(filter, update);
            //await _matchesCollection.UpdateOneAsync(g => g.Id == id, updatedMatch);
        }

        public async Task DeleteAsync(string id)
        {
            await _matchesCollection.DeleteOneAsync(m => m.Id == id);
        }
    }
}
