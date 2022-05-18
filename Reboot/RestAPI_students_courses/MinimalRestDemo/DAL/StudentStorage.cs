using System.Runtime.CompilerServices;
using RestAPI_students_courses.DAL.Models;

namespace RestAPI_students_courses.DAL
{
    public class StudentStorage
    {
        private readonly IDictionary<int, Student> _students;

        private int _id;

        public StudentStorage()
        {
            _students = new Dictionary<int, Student>();
        }

        public bool CreateStudent(Student student)
        {
            if (_students.Values.Contains(student))
                return false;
            _students.Add(_id++, student);
            return true;
        }

        public ICollection<Student> GetAllStudents()
        {
            return _students.Values;
        }

        public Student? GetStudent(int id)
        {
            if (!_students.Keys.Contains(id))
                return null;
            return _students[id];
        }

        public bool UpdateStudent(int id, Student student)
        {
            if (!_students.Keys.Contains(id))
            {
                return false;
            }

            _students[id] = student;

            return true;
        }

        public KeyValuePair<int, Student>? GetStudentWithEmail(string email)
        {

            foreach (KeyValuePair<int, Student> student in _students)
            {
                if(student.Value.Email == email)
                {
                    return student;
                }
            }
            return null;
        }

        public bool UpdateStudentName(int id, string firstName, string lastName)
        {
            if (!_students.Keys.Contains(id))
            {
                return false;
            }

            _students[id].FirstName = firstName;
            _students[id].LastName = lastName;

            return true;
        }

        public bool UpdateStudentEmail(int id, string email)
        {
            if (!_students.Keys.Contains(id))
            {
                return false;
            }

            _students[id].Email = email;

            return true;
        }

        //not in customer's request!!!
        public bool DeleteStudent(int id)
        {
            if (!_students.Keys.Contains(id))
            {
                return false;
            }

            _students.Remove(id);

            return true;
        }
    }
}
