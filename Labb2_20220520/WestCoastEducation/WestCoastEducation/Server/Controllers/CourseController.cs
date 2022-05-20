using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.Server.DAL;
using WestCoastEducation.Shared;

namespace WestCoastEducation.Server.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        public class CourseController : ControllerBase
        {
            private readonly CourseRepository _courseRepository;

            public CourseController(CourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }

            [HttpGet]
            public async Task<ActionResult<ICollection<Course>>> GetCourses()
            {
                var courses = await _courseRepository.GetAllCoursesAsync();
                return Ok();
            }

            [HttpPost]
            public async Task<IActionResult> PostCourse(Course course)
            {
                var result = await _courseRepository.CreateCourseAsync(course);
                return result ? Ok() : BadRequest();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCourseAsync(int id)
            {
                _courseRepository.DeleteCourse(id);
                return Ok();
            }
        }
    }

