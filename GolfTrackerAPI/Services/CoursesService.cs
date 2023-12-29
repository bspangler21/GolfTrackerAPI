using GolfTrackerAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GolfTrackerAPI.Services
{
    public class CoursesService
    {
        private readonly IMongoCollection<Courses> _coursesCollection;

        public CoursesService(IOptions<CoursesDatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            _coursesCollection = database.GetCollection<Courses>(databaseSettings.Value.CoursesCollectionName);
        }

        public async Task<List<Courses>> GetCoursesAsync()
        {

            var matches = await _coursesCollection.FindAsync(_ => true);
            
            return await matches.ToListAsync();
        }

        public async Task<Courses> GetCourseAsync(string id)
        {
            var match = await _coursesCollection.FindAsync(c => c.Id == id);

            return await match.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Courses newCourse)
        {
            await _coursesCollection.InsertOneAsync(newCourse);
        }

        public async Task UpdateAsync(string id, Courses updatedCourse)
        {
            FilterDefinition<Courses> filter = Builders<Courses>.Filter.Eq(c => c.Id, id);
            UpdateDefinition<Courses> update = Builders<Courses>.Update
                .Set(c => c.name, updatedCourse.name)
                .Set(c => c.description, updatedCourse.description)
                .Set(c => c.address, updatedCourse.address)
                .Set(c => c.city, updatedCourse.city)
                .Set(c => c.state, updatedCourse.state)
                .Set(c => c.zip, updatedCourse.zip)
                .Set(c => c.holes, updatedCourse.holes)
                .Set(c => c.par, updatedCourse.par);
            await _coursesCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string id)
        {
            await _coursesCollection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
