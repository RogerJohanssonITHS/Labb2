using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestCoastEducation.Shared
{
    public class Student
    {
        public Student(string firstName, string lastName, string email, string phoneNr, string street, string postalCode, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNr = phoneNr;
            Street = street;
            PostalCode = postalCode;
            City = city;
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



        public Student()
        {
            Courses = new HashSet<Course>();
        }
    }
}

