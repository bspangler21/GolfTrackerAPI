using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Golfers updatedGolfer)
        {
            var golfer = await _golfService.GetGolferAsync(id);

            if (golfer == null)
            {
                return NotFound();
            }

            updatedGolfer.Id = golfer.Id;

            await _golfService.UpdateAsync(id, updatedGolfer);

            return Ok();
        }

       

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var golfer = await _golfService.GetGolferAsync(id);

            if (golfer == null)
            {
                return NotFound();
            }

            await _golfService.DeleteAsync(id);

            return Ok();
        }   
    }
}
