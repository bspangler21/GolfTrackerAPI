using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GolfTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private readonly DatesService _dateService;

        public DatesController(DatesService dateService)
        {
            _dateService = dateService;
        }

        [HttpGet]
        public async Task<List<Dates>> Get() => await _dateService.GetDatesAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Dates>> Get(string id) => await _dateService.GetDateAsync(id);


        [HttpPost]
        public async Task<IActionResult> Create(Dates newDate)
        {
            await _dateService.CreateAsync(newDate);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Dates updatedDate)
        {
            var leagueDate = await _dateService.GetDateAsync(id);

            if (leagueDate == null)
            {
                return NotFound();
            }

            updatedDate.Id = leagueDate.Id;

            await _dateService.UpdateAsync(id, updatedDate);

            return Ok();
        }

       

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var leagueDate = await _dateService.GetDateAsync(id);

            if (leagueDate == null)
            {
                return NotFound();
            }

            await _dateService.DeleteAsync(id);

            return Ok();
        }   
    }
}
