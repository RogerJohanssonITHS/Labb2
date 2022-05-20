using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestCoastEducation.Shared
{
    public class Course
    {
        public Course(int courseNumber, string courseName, string courseDescription, int courseLength, string courseLevel, bool courseStatus)
        {
            CourseNumber = courseNumber;
            CourseName = courseName;
            CourseDescription = courseDescription;
            CourseLength = courseLength;
            CourseLevel = courseLevel;
            CourseStatus = courseStatus;

        }
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int CourseLength { get; set; }
        public string CourseLevel { get; set; }
        public bool CourseStatus { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            Students = new HashSet<Student>();
        }

        public static Course CopyCourse(Course course)
        {
            var courseCopy = new Course();
            courseCopy.CourseNumber = course.CourseNumber;
            courseCopy.CourseName = course.CourseName;
            courseCopy.CourseDescription = course.CourseDescription;
            courseCopy.CourseLength = course.CourseLength;
            courseCopy.CourseLevel = course.CourseLevel;
            courseCopy.CourseStatus = course.CourseStatus;
            return courseCopy;
        }
    }
}

