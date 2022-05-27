using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WestCoastEducation.Shared
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        [JsonIgnore]
        public virtual ICollection<Course> Courses { get; set; }

    }
}

