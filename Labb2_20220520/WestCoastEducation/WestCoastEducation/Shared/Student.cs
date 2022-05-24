using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Course> Courses { get; set; }

        //public Student()
        //{
        //    Courses = new HashSet<Course>();
        //}
        public static Student CopyStudent(Student student)
        {
            var studentCopy = new Student();
            studentCopy.Id = student.Id;
            studentCopy.FirstName = student.FirstName;
            studentCopy.LastName = student.LastName;
            studentCopy.Email = student.Email;
            studentCopy.PhoneNr = student.PhoneNr;
            studentCopy.Street = student.Street;
            studentCopy.PostalCode = student.PostalCode;
            studentCopy.City = student.City;
            return studentCopy;
        }

    }
}

