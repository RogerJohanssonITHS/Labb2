﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ICollection<Student>>> GetStudentEmail(string email)
        {
            var student = await _studentRepository.GetStudentEmailAsync(email);
            return Ok(student);
        }

        [HttpGet("{id}/courses")]
        public IActionResult GetUserGroups(int id)
        {
            var user = _studentRepository.GetUserCourses(id);

            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            var result = await _studentRepository.CreateStudentAsync(student);
            return result ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            //student.Id = id;
            var result = await _studentRepository.PutStudentAsync(student);
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            _studentRepository.DeleteStudent(id);
            return Ok();
        }
    }
}
