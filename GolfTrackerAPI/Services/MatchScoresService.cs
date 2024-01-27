using GolfTrackerAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public class MatchScoresService
    {
        private readonly IMongoCollection<MatchScores> _matchScoresCollection;

        public MatchScoresService(IOptions<MatchScoresDatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            _matchScoresCollection = database.GetCollection<MatchScores>(databaseSettings.Value.MatchScoresCollectionName);
        }

        public async Task<List<MatchScores>> GetMatchScoresAsync()
        {

            var matchScores = await _matchScoresCollection.FindAsync(_ => true);
            
            return await matchScores.ToListAsync();
        }

        public async Task<MatchScores> GetMatchScoreAsync(string id)
        {
            var matchScore = await _matchScoresCollection.FindAsync(m => m.Id == id);

            return await matchScore.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(MatchScores newMatchScore)
        {
            await _matchScoresCollection.InsertOneAsync(newMatchScore);
        }

        /// <summary>
        /// Asynchronously updates a match score.
        /// </summary>
        /// <param name="id">The ID of the match score to update.</param>
        /// <param name="updatedMatchScore">The updated match score.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateAsync(string id, MatchScores updatedMatchScore)
        {
            FilterDefinition<MatchScores> filter = Builders<MatchScores>.Filter.Eq(m => m.Id, id);
            UpdateDefinition<MatchScores> update = Builders<MatchScores>.Update
                .Set(m => m.matchId, updatedMatchScore.matchId)
                .Set(m => m.golferId, updatedMatchScore.golferId)
                .Set(m => m.totalScore, updatedMatchScore.totalScore)
                .Set(m => m.holeScores, updatedMatchScore.holeScores);
            await _matchScoresCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string id)
        {
            await _matchScoresCollection.DeleteOneAsync(m => m.Id == id);
        }
    }
}
