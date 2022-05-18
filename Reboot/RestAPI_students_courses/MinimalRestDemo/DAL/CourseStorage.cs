using System.Runtime.CompilerServices;
using RestAPI_students_courses.DAL.Models;

namespace RestAPI_students_courses.DAL
{
    public class CourseStorage
    {
        private readonly IDictionary<int, Course> _courses;

        private int _id;

        public CourseStorage()
        {
            _courses = new Dictionary<int, Course>();
        }

        public bool CreateCourse(Course course)
        {
            if (_courses.Values.Contains(course))
                return false;
            _courses.Add(_id++, course);
            return true;
        }

        public ICollection<Course> GetAllCourses()
        {
            return _courses.Values;
        }

        public Course? GetCourse(int id)
        {
            if (!_courses.Keys.Contains(id))
                return null;
            return _courses[id];
        }

        public bool UpdateStudent(int id, Course course)
        {
            if (!_courses.Keys.Contains(id))
            {
                return false;
            }

            _courses[id] = course;

            return true;
        }

        public bool UpdateCourseName(int id, string courseName)
        {
            if (!_courses.Keys.Contains(id))
            {
                return false;
            }

            _courses[id].CourseName = courseName;

            return true;
        }

        public bool UpdateCourseStatus(int id)
        {
            if (_courses.Keys.Contains(id) && _courses[id].CourseStatus)
            {
                _courses[id].CourseStatus = false;
                return true;
            }

            return false;
        }

        public bool DeleteCourse(int id)
        {
            if (!_courses.Keys.Contains(id))
            {
                return false;
            }

            _courses.Remove(id);

            return true;
        }
    }
}
