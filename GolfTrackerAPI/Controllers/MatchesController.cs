using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GolfTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly MatchesService _matchService;

        public MatchesController(MatchesService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<List<Matches>> Get() => await _matchService.GetMatchesAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Matches>> Get(string id) => await _matchService.GetMatchAsync(id);


        [HttpPost]
        public async Task<IActionResult> Create(Matches newMatch)
        {
            await _matchService.CreateAsync(newMatch);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Matches updatedMatch)
        {
            var match = await _matchService.GetMatchAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            updatedMatch.Id = match.Id;

            await _matchService.UpdateAsync(id, updatedMatch);

            return Ok();
        }

       

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var match = await _matchService.GetMatchAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            await _matchService.DeleteAsync(id);

            return Ok();
        }   
    }
}
