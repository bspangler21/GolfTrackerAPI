using GolfTrackerAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public class DatesService
    {
        private readonly IMongoCollection<Dates> _datesCollection;

        public DatesService(IOptions<DatesDatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            _datesCollection = database.GetCollection<Dates>(databaseSettings.Value.DatesCollectionName);
        }

        public async Task<List<Dates>> GetDatesAsync()
        {

            var leagueDates = await _datesCollection.FindAsync(_ => true);
            
            return await leagueDates.ToListAsync();
        }

        public async Task<Dates> GetDateAsync(string id)
        {
            var match = await _datesCollection.FindAsync(d => d.Id == id);

            return await match.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Dates newDate)
        {
            await _datesCollection.InsertOneAsync(newDate);
        }

        public async Task UpdateAsync(string id, Dates updatedDate)
        {
            FilterDefinition<Dates> filter = Builders<Dates>.Filter.Eq(d => d.Id, id);
            UpdateDefinition<Dates> update = Builders<Dates>.Update
                .Set(d => d.leagueId, updatedDate.leagueId)
                .Set(d => d.matchDate, updatedDate.matchDate)
                .Set(d => d.matchWeekNumber, updatedDate.matchWeekNumber);
            await _datesCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string id)
        {
            await _datesCollection.DeleteOneAsync(d => d.Id == id);
        }
    }
}
