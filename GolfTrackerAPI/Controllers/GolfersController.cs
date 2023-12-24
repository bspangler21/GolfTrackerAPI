using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolfTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GolfersController : ControllerBase
    {
        private readonly GolfService _golfService;

        public GolfersController(GolfService golfService)
        {
            _golfService = golfService;
        }

        [HttpGet]
        public async Task<List<Golfers>> Get() => await _golfService.GetGolfersAsync();
    }
}
