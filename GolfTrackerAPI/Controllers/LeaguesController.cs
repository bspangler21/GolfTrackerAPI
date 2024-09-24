using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GolfTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly LeaguesService _leagueService;

        public LeaguesController(LeaguesService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<List<Leagues>> Get() => await _leagueService.GetLeaguesAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Leagues>> Get(string id) => await _leagueService.GetLeagueAsync(id);


        [HttpPost]
        public async Task<IActionResult> Create(Leagues newLeague)
        {
            await _leagueService.CreateAsync(newLeague);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Leagues updatedLeague)
        {
            var league = await _leagueService.GetLeagueAsync(id);

            if (league == null)
            {
                return NotFound();
            }

            updatedLeague.Id = league.Id;

            await _leagueService.UpdateAsync(id, updatedLeague);

            return Ok();
        }

       

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var league = await _leagueService.GetLeagueAsync(id);

            if (league == null)
            {
                return NotFound();
            }

            await _leagueService.DeleteAsync(id);

            return Ok();
        }   
    }
}
