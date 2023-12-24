using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using MongoDB.Bson;
using MongoDB.Driver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GolferDatabaseSettings>(builder.Configuration.GetSection("GolferDatabase"));
builder.Services.AddSingleton<GolfService>();
builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();



//const string connectionUri = "mongodb+srv://bspangler21:CM2xP2C2Ul5jLf7l@spangdev.xsqup9m.mongodb.net/?retryWrites=true&w=majority";

//var settings = MongoClientSettings.FromConnectionString(connectionUri);

// Set the ServerApi field of the settings object to Stable API version 1
//settings.ServerApi = new ServerApi(ServerApiVersion.V1);

// Create a new client and connect to the server
//var client = new MongoClient(settings);

// Send a ping to confirm a successful connection
/*try
{
    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}*/

/*app.MapGet("/golfer/{golferId:string}", () =>
{
    try
    {
        var result = client.GetDatabase("golf-tracker").GetCollection<BsonDocument>("golfers");
        var filter = Builders<BsonDocument>.Filter.Eq("FirstName", "Brett");
        var document = result.Find(filter).First();
        Console.WriteLine(document);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
});*/

/*try
{
    var result = client.GetDatabase("golf-tracker").GetCollection<BsonDocument>("golfers");
    var filter = Builders<BsonDocument>.Filter.Eq("FirstName", "Brett");
    var document = result.Find(filter).First();
    Console.WriteLine(document);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}*/

/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};*/

/*app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();*/

app.Run();

/*internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/
