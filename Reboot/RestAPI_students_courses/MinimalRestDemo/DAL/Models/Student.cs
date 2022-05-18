namespace RestAPI_students_courses.DAL.Models
{
    public record Student
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
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
