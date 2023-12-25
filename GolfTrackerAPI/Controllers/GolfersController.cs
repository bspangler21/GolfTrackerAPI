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

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Golfers>> Get(string id) => await _golfService.GetGolferAsync(id);


        [HttpPost]
        public async Task<IActionResult> Create(Golfers newGolfer)
        {
            await _golfService.CreateAsync(newGolfer);

            return Ok();
        }
    }
}
