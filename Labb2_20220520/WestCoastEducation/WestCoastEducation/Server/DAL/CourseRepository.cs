using Microsoft.EntityFrameworkCore;
using WestCoastEducation.Shared;

namespace WestCoastEducation.Server.DAL
{
    public class CourseRepository
    {
        private readonly CourseContext _courseContext;

        public CourseRepository(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public async Task<bool> CreateCourseAsync(Course? course)
        {
            if (course is null)
            {
                return false;
            }

            if (GetCourse(course.Id) is not null)
                return false;
            await _courseContext.Courses.AddAsync(course);
            await _courseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatchCourseAsync(Course course)
        {
            if (course is null)
            {
                return false;
            }

            _courseContext.Courses.Update(course);
            _courseContext.SaveChanges();
            return true;
        }

        public async Task<ICollection<Course>> GetAllCoursesAsync()
        {
            var courses = _courseContext.Courses;
            return await courses.ToListAsync();
        }



        public async Task<Course> GetCourseNumberAsync(int courseNumber)
        {
            var course = _courseContext.Courses.FirstOrDefault(c => c.CourseNumber == courseNumber);
            return course;
        }

        public Course? GetCourse(int id)
        {
            return _courseContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public bool DeleteCourse(int id)
        {
            var courseToDelete = GetCourse(id);
            if (courseToDelete is null)
            {
                return false;
            }

            _courseContext.Courses.Remove(courseToDelete);
            _courseContext.SaveChanges();
            return true;
        }

        //for many to many
        public ICollection<Student>? GetCourseStudents(int id)
        {
            var courseStudents = _courseContext.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == id);
            if (courseStudents is null)
                return null;

            return courseStudents.Students;
        }

        public void Create(Course course)
        {
            _courseContext.Courses.Add(course);
        }

        public bool UpdateCourse(int id, Course course)
        {
            var existingCourse = _courseContext.Courses.FirstOrDefault(c => c.Id == id);
            if (existingCourse is null)
            {
                return false;
            }

            course.Id = existingCourse.Id;

            existingCourse = course;

            return true;
        }
    }
}
