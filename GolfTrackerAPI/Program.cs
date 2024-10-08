using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using MongoDB.Bson;
using MongoDB.Driver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GolferDatabaseSettings>(builder.Configuration.GetSection("GolferDatabase"));
builder.Services.AddSingleton<GolfService>();
builder.Services.Configure<MatchesDatabaseSettings>(builder.Configuration.GetSection("MatchesDatabase"));
builder.Services.AddSingleton<MatchesService>();
builder.Services.Configure<LeaguesDatabaseSettings>(builder.Configuration.GetSection("LeaguesDatabase"));
builder.Services.AddSingleton<LeaguesService>();
builder.Services.Configure<CoursesDatabaseSettings>(builder.Configuration.GetSection("CoursesDatabase"));
builder.Services.AddSingleton<CoursesService>();
builder.Services.Configure<HolesDatabaseSettings>(builder.Configuration.GetSection("HolesDatabase"));
builder.Services.AddSingleton<HolesService>();
builder.Services.Configure<DatesDatabaseSettings>(builder.Configuration.GetSection("DatesDatabase"));
builder.Services.AddSingleton<DatesService>();
builder.Services.Configure<MatchScoresDatabaseSettings>(builder.Configuration.GetSection("MatchScoresDatabase"));
builder.Services.AddSingleton<MatchScoresService>();
builder.Services.AddControllers();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//});

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

app.UseCors(p => p.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
//app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
//app.UseCors("AllowAll");

app.MapControllers();

app.Run();
