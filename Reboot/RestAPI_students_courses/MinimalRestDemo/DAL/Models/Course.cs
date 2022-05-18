namespace RestAPI_students_courses.DAL.Models
{
    public record Course
    {
        public Course(string courseNumber, string courseName, string courseDescription, string courseLength, string courseLevel, bool courseStatus)
        {
            CourseNumber = courseNumber;
            CourseName = courseName;
            CourseDescription = courseDescription;
            CourseLength = courseLength;
            CourseLevel = courseLevel;
            CourseStatus = courseStatus;

        }

        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseLength { get; set; }
        public string CourseLevel { get; set; }
        public bool CourseStatus { get; set; }
    }
}
