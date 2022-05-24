using Microsoft.EntityFrameworkCore;
using WestCoastEducation.Shared;

namespace WestCoastEducation.Server.DAL
{
    public class StudentRepository
    {
        private readonly CourseContext _studentContext;

        public StudentRepository(CourseContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<bool> CreateStudentAsync(Student? student)
        {
            if (student is null)
            {
                return false;
            }

            if (GetStudent(student.Id) is not null)
                return false;
            await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchStudentAsync(Student student)
        {
            if (student is null)
            {
                return false;
            }

            _studentContext.Students.Update(student);
            _studentContext.SaveChanges();
            return true;
        }

        public async Task<ICollection<Student>> GetAllStudentsAsync()
        {
            var students = _studentContext.Students;
            return await students.ToListAsync();
        }

        public async Task<Student> GetStudentEmailAsync(string email)
        {
            var student = _studentContext.Students.FirstOrDefault(s => s.Email == email);
            return student;
        }

        public Student? GetStudent(int id)
        {
            return _studentContext.Students.FirstOrDefault(s => s.Id == id);
        }
        public bool DeleteStudent(int id)
        {
            var studentToDelete = GetStudent(id);
            if (studentToDelete is null)
            {
                return false;
            }

            _studentContext.Students.Remove(studentToDelete);
            _studentContext.SaveChanges();
            return true;
        }
    }
}
