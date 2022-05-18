using ControllerRestDemo.DAL.Models;

namespace ControllerRestDemo.DAL;

public interface IStudentRepository : IDisposable
{
    void Create(Student student);
    ICollection<Student> GetAllStudents();
    Student? GetStudent(int id);
    Student? GetStudentWithEmail(string email);
    bool UpdateStudent(int id, Student student);
    bool UpdateStudentFirstName(int id, string firstname);
    bool UpdateStudentLastName(int id, string lastname);
    bool UpdateStudentEmail(int id, string email);
    bool DeleteStudent(int id);
}