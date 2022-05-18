using ControllerRestDemo.DAL.Models;

namespace ControllerRestDemo.DAL
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private readonly StudentContext _studentContext;

        private readonly IDictionary<int, Student> _students;

        //private int _id = 2;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Create(Student student)
        {
            _studentContext.Students.Add(student);
        }

        public ICollection<Student> GetAllStudents()
        {
            return _students.Values;
        }

        public Student? GetStudent(int id)
        {
            if (!_students.Keys.Contains(id))
            {
                return null;
            }

            return _students[id];
        }

        public StudentContext Get_studentContext()
        {
            return _studentContext;
        }

        public Student? GetStudentWithEmail(string email)
        {
            var allStudents = GetAllStudents();
            foreach (Student student in allStudents)
            {
                if (student.Email == email)
                {
                    return student;
                }
            }
            return null;
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

        public bool UpdateStudentFirstName(int id, string firstname)
        {
            if (!_students.Keys.Contains(id))
            {
                return false;
            }

            _students[id].FirstName = firstname;

            return true;
        }

        public bool UpdateStudentLastName(int id, string lastname)
        {
            if (!_students.Keys.Contains(id))
            {
                return false;
            }

            _students[id].FirstName = lastname;

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

        public bool DeleteStudent(int id)
        {
            if (!_students.Keys.Contains(id))
            {
                return false;
            }

            _students.Remove(id);

            return true;
        }
        
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
