using GolfTrackerAPI.Models;
using GolfTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GolfTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesService _courseService;

        public CoursesController(CoursesService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<List<Courses>> Get() => await _courseService.GetCoursesAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Courses>> Get(string id) => await _courseService.GetCourseAsync(id);


        [HttpPost]
        public async Task<IActionResult> Create(Courses newCourse)
        {
            await _courseService.CreateAsync(newCourse);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Courses updatedCourse)
        {
            var course = await _courseService.GetCourseAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            updatedCourse.Id = course.Id;

            await _courseService.UpdateAsync(id, updatedCourse);

            return Ok();
        }

       

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var course = await _courseService.GetCourseAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            await _courseService.DeleteAsync(id);

            return Ok();
        }   
    }
}
