namespace WestCoastEducation.Shared
{
    public record Course
    {
        public Course(int courseNumber, string courseName, string courseDescription, string courseLength, string courseLevel, bool courseStatus)
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
        public string CourseLength { get; set; }
        public string CourseLevel { get; set; }
        public bool CourseStatus { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            Students = new HashSet<Student>();
        }
    }
}