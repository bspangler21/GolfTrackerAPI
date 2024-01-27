using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GolfTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchScoresController : ControllerBase
    {
        private readonly MatchScoresService _matchScoreService;

        public MatchScoresController(MatchScoresService matchScoreService)
        {
            _matchScoreService = matchScoreService;
        }

        [HttpGet]
        public async Task<List<MatchScores>> Get() => await _matchScoreService.GetMatchScoresAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<MatchScores>> Get(string id) => await _matchScoreService.GetMatchScoreAsync(id);


        [HttpPost]
        public async Task<IActionResult> Create(MatchScores newMatchScore)
        {
            await _matchScoreService.CreateAsync(newMatchScore);

            return Ok();
        }

        /// <summary>
        /// Updates a match score with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the match score to update.</param>
        /// <param name="updatedMatchScore">The updated match score object.</param>
        /// <returns>An IActionResult representing the result of the update operation.</returns>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, MatchScores updatedMatchScore)
        {
            var matchScore = await _matchScoreService.GetMatchScoreAsync(id);

            if (matchScore == null)
            {
                return NotFound();
            }

            updatedMatchScore.Id = matchScore.Id;

            await _matchScoreService.UpdateAsync(id, updatedMatchScore);

            return Ok();
        }

       

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var matchScore = await _matchScoreService.GetMatchScoreAsync(id);

            if (matchScore == null)
            {
                return NotFound();
            }

            await _matchScoreService.DeleteAsync(id);

            return Ok();
        }   
    }
}
