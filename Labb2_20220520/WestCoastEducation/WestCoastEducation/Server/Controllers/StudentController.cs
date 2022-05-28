using Microsoft.AspNetCore.Mvc;
using WestCoastEducation.Server.DAL;
using WestCoastEducation.Shared;

namespace WestCoastEducation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Student>>> GetStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<ICollection<Student?>>> GetStudentEmail(string email)
        {
            var student = await _studentRepository.GetStudentEmailAsync(email);
            return student is not null ? Ok(student) : NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            var result = await _studentRepository.CreateStudentAsync(student);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Student student)
        {
            var result = await _studentRepository.PutStudentAsync(student);
            return result ? Ok() : BadRequest();
        }


        //for many-to-many
        [HttpGet("{id}/courses")]
        public IActionResult GetStudentCourses(int id)
        {
            var studentCourses = _studentRepository.GetStudentCoursesAsync(id);

            return studentCourses is not null ? Ok(studentCourses) : NotFound();
        }

        [HttpPost("{id}/courses")]
        public async Task<IActionResult> AddStudentToCourse(int id, Course? course)
        {
            var result = await _studentRepository.AddStudentToCourseAsync(id, course);

            return result ? Ok() : BadRequest();
        }
    }
}
