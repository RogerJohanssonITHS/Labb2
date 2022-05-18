using ControllerRestDemo.DAL;
using ControllerRestDemo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllerRestDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly UnitOfWork _unitOfWork;

        public StudentController([FromServices] UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Students
        [HttpGet]
        public IResult Get()
        {
            var students = _unitOfWork.StudentRepository.GetAllStudents();
            return students.Count > 0 ? Results.Ok(students): Results.NotFound();
        }

        // GET api/Student/2
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var student = _unitOfWork.StudentRepository.GetStudent(id);

            return student is not null ? Results.Ok(student) : Results.NotFound();
        }

        // GET api/Student/email/{email}
        [HttpGet("{email}")]
        public IResult Get(string email)
        {
            var student = _unitOfWork.StudentRepository.GetStudentWithEmail(email);

            return student is not null ? Results.Ok(student) : Results.NotFound();
        }

        // POST api/Student
        [HttpPost]
        public IResult Post([FromBody] Student student)
        {
            _unitOfWork.StudentRepository.Create(student);
            _unitOfWork.Save();
            return Results.Ok();
        }

        // PUT api/Student/2
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] Student student)
        {
            _unitOfWork.StudentRepository.UpdateStudent(id, student);
            return Results.Ok();
        }

        // PATCH api/Student/FirstName/2
        [HttpPatch("FirstName/{id}")]
        public IResult PatchFirstName(int id, string firstName)
        {
            if (_unitOfWork.StudentRepository.UpdateStudentFirstName(id, firstName))
            {
                return Results.Ok(_unitOfWork.StudentRepository.GetStudent(id));
            }

            return Results.NotFound();
        }

        // PATCH api/Student/LastName/2
        [HttpPatch("LastName/{id}")]
        public IResult PatchLastName(int id, string lastName)
        {
            if (_unitOfWork.StudentRepository.UpdateStudentLastName(id, lastName))
            {
                return Results.Ok(_unitOfWork.StudentRepository.GetStudent(id));
            }

            return Results.NotFound();
        }

        // DELETE api/Student/2
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            _unitOfWork.StudentRepository.DeleteStudent(id);
            return Results.Ok();
        }
    }
}
