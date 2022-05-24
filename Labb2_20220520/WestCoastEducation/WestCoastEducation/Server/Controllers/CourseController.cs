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
            return Ok(courses);
        }


        [HttpGet("{courseNumber}") ]
        public async Task<ActionResult<ICollection<Course>>> GetCourseNumber(int courseNumber)
        {
            var course = await _courseRepository.GetCourseNumberAsync(courseNumber);
            return Ok(course);
        }


        [HttpPost]
        public async Task<IActionResult> PostCourse(Course course)
        {
            var result = await _courseRepository.CreateCourseAsync(course);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PatchCourse(int id, Course course)
        {
            //student.Id = id;
            var result = await _courseRepository.PatchCourseAsync(course);
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

