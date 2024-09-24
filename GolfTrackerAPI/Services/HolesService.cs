using GolfTrackerAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public class HolesService
    {
        private readonly IMongoCollection<Holes> _holesCollection;

        public HolesService(IOptions<HolesDatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            _holesCollection = database.GetCollection<Holes>(databaseSettings.Value.HolesCollectionName);
        }

        public async Task<List<Holes>> GetHolesAsync()
        {

            var matches = await _holesCollection.FindAsync(_ => true);
            
            return await matches.ToListAsync();
        }

        public async Task<Holes> GetHoleAsync(string id)
        {
            var hole = await _holesCollection.FindAsync(h => h.Id == id);

            return await hole.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Holes newHole)
        {
            await _holesCollection.InsertOneAsync(newHole);
        }

        public async Task UpdateAsync(string id, Holes updatedHole)
        {
            FilterDefinition<Holes> filter = Builders<Holes>.Filter.Eq(h => h.Id, id);
            UpdateDefinition<Holes> update = Builders<Holes>.Update
                .Set(h => h.courseId, updatedHole.courseId)
                .Set(h => h.holeNumber, updatedHole.holeNumber)
                .Set(h => h.holePar, updatedHole.holePar)
                .Set(h => h.holeHandicap, updatedHole.holeHandicap)
                .Set(h => h.holeLength, updatedHole.holeLength);
            await _holesCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string id)
        {
            await _holesCollection.DeleteOneAsync(h => h.Id == id);
        }
    }
}
