using ControllerRestDemo.DAL;
using ControllerRestDemo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllerRestDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly UnitOfWork _unitOfWork;

        public CourseController([FromServices] UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Course
        [HttpGet]
        public IResult Get()
        {
            var courses = _unitOfWork.CourseRepository.GetAllCourses();
            return courses.Count > 0 ? Results.Ok(courses) : Results.NotFound();
        }

        // GET api/Course/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var course = _unitOfWork.CourseRepository.GetCourse(id);

            return course is not null ? Results.Ok(course) : Results.NotFound();
        }

        // POST api/Course
        [HttpPost]
        public IResult Post([FromBody] Course course)
        {
            _unitOfWork.CourseRepository.Create(course);
            _unitOfWork.Save();
            return Results.Ok();
        }

        //retires course
        // PATCH api/Course 
        [HttpPatch("{id}")]
        public IResult Patch(int id)
        {
            if (_unitOfWork.CourseRepository.UpdateCourse(id))
            {
                return Results.Ok(_unitOfWork.StudentRepository.GetStudent(id));
            }

            return Results.NotFound();
        }

        // DELETE api/Course/3
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            _unitOfWork.CourseRepository.DeleteCourse(id);
            return Results.Ok();
        }
    }
}
