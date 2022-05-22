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
    }
}
