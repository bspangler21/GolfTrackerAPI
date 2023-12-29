using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GolfTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolesController : ControllerBase
    {
        private readonly HolesService _holeService;

        public HolesController(HolesService holeService)
        {
            _holeService = holeService;
        }

        [HttpGet]
        public async Task<List<Holes>> Get() => await _holeService.GetHolesAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Holes>> Get(string id) => await _holeService.GetHoleAsync(id);


        [HttpPost]
        public async Task<IActionResult> Create(Holes newHole)
        {
            await _holeService.CreateAsync(newHole);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Holes updatedHole)
        {
            var hole = await _holeService.GetHoleAsync(id);

            if (hole == null)
            {
                return NotFound();
            }

            updatedHole.Id = hole.Id;

            await _holeService.UpdateAsync(id, updatedHole);

            return Ok();
        }

       

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var hole = await _holeService.GetHoleAsync(id);

            if (hole == null)
            {
                return NotFound();
            }

            await _holeService.DeleteAsync(id);

            return Ok();
        }   
    }
}
