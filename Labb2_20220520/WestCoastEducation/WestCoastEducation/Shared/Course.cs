using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WestCoastEducation.Shared
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseDescription { get; set; } = string.Empty;
        public int CourseLength { get; set; }
        public string CourseLevel { get; set; } = string.Empty;
        public bool CourseStatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }

    }
}

