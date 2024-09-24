using GolfTrackerAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public class LeaguesService
    {
        private readonly IMongoCollection<Leagues> _leaguesCollection;

        public LeaguesService(IOptions<LeaguesDatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            _leaguesCollection = database.GetCollection<Leagues>(databaseSettings.Value.LeaguesCollectionName);
        }

        public async Task<List<Leagues>> GetLeaguesAsync()
        {

            var leagues = await _leaguesCollection.FindAsync(_ => true);
            
            return await leagues.ToListAsync();
        }

        public async Task<Leagues> GetLeagueAsync(string id)
        {
            var league = await _leaguesCollection.FindAsync(L => L.Id == id);

            return await league.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Leagues newLeague)
        {
            await _leaguesCollection.InsertOneAsync(newLeague);
        }

        /// <summary>
        /// Updates a league in the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the league to update.</param>
        /// <param name="updatedLeague">The updated league object.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateAsync(string id, Leagues updatedLeague)
        {
            FilterDefinition<Leagues> filter = Builders<Leagues>.Filter.Eq(L => L.Id, id);
            UpdateDefinition<Leagues> update = Builders<Leagues>.Update
                .Set(L => L.name, updatedLeague.name);
            await _leaguesCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string id)
        {
            await _leaguesCollection.DeleteOneAsync(L => L.Id == id);
        }
    }
}
