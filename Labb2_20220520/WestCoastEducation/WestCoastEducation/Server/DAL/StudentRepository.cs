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

        public async Task<bool> PutStudentAsync(Student student)
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

        //for many to many
        public ICollection<Course>? GetStudentCourses(int id)
        {
            var studentCourses = _studentContext.Students.Include(s => s.Courses).FirstOrDefault(s => s.Id == id);
            if (studentCourses is null)
                return null;

            return studentCourses.Courses;
        }

        public async Task<bool> AddStudentToCourseAsync(int studentId, Course ? course)
        {
            var studentForCourse = _studentContext.Students.FirstOrDefault(s => s.Id == studentId);
            if (studentForCourse is null)
            {
                return false;
            }

            var courseForStudent = _studentContext.Courses.FirstOrDefault(c => c.CourseNumber == course.CourseNumber);
            if (courseForStudent is null)
            {
                return false;
            }

            courseForStudent.Students.Add(studentForCourse);
            await _studentContext.SaveChangesAsync();
            return true;
        }
    }
}
