using WestCoastEducation.Shared;

namespace ControllerRestDemo.Server.DAL
{
    public class CourseRepository : ICourseRepository, IDisposable
    {
        private readonly StudentContext _studentContext;

        //private readonly IDictionary<int, Course> _courses;

        //private int _id = 2;

        public CourseRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Create(Course course)
        {
            _studentContext.Courses.Add(course);
        }

        public ICollection<Course> GetAllCourses()
        {
            return _studentContext.Courses.ToList();
        }

        public Course? GetCourse(int id)
        {
           return _studentContext.Courses.FirstOrDefault(g => g.Id == id);
        }

        //retires course
        public bool UpdateCourse(int id)
        {
            var validCourse = _studentContext.Courses.FirstOrDefault(u => u.Id == id);
            if (validCourse is null)
            {
                return false;
            }

            validCourse.CourseStatus = false;

            return true;
        }


        public bool DeleteCourse(int id)
        {
            var validCourse = _studentContext.Courses.FirstOrDefault(u => u.Id == id);
            if (validCourse is null)
            {
                return false;
            }
            _studentContext.Courses.Remove(validCourse);

            return true;
        }
        
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
