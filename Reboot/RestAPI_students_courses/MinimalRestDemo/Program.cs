using Microsoft.AspNetCore.Mvc;
using RestAPI_students_courses.DAL;
using RestAPI_students_courses.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<StudentStorage>();

builder.Services.AddSingleton<CourseStorage>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/students", ([FromServices] StudentStorage storage) =>
{
    var students = storage.GetAllStudents();

    if (students.Count <= 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(students);
});

app.MapGet("/students/{id}", ([FromServices] StudentStorage storage, int id) =>
{
    var student = storage.GetStudent(id);

    return student is not null ? Results.Ok(student): Results.NotFound();
});

app.MapGet("/students/email/{email}", ([FromServices] StudentStorage storage, string email) =>
{
    //app.MapGet("/students/{email}",
    //(string email) => $"The user id is {userId} and book id is {bookId}");

    //find student with email. Create method in StudentStorage.cs. with name GetStudentWithEmail.
    var student = storage.GetStudentWithEmail(email);

    return student is not null ? Results.Ok(student) : Results.NotFound();
});

app.MapPost("/students", ([FromServices] StudentStorage storage, Student student) =>
{
    if (student is null)
        return Results.BadRequest();

    return storage.CreateStudent(student) ? Results.Ok() : Results.Conflict();
});

app.MapPut("/students/{id}", ([FromServices] StudentStorage storage, int id, Student student) =>
{
    if (string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.Email))
        return Results.BadRequest();

    return storage.UpdateStudent(id, student) ? Results.Ok(): Results.NotFound();
});

//en patch-metod för alla fält???
app.MapMethods("/students/name/{id}",  new [] {"PATCH"}, 
    ([FromServices] StudentStorage storage, int id, string firstname, string lastname) =>
{
    if (string.IsNullOrEmpty(firstname.Trim()) || string.IsNullOrEmpty(lastname.Trim()))
    {
        return Results.BadRequest();
    }

    return storage.UpdateStudentName(id, firstname, lastname) ?
        Results.Ok(storage.GetStudent(id)) : Results.NotFound();
});

app.MapMethods("/students/email/{id}", new[] { "PATCH" }, 
    ([FromServices] StudentStorage storage, int id, string email) =>
{
    if (string.IsNullOrEmpty(email.Trim()))
    {
        return Results.BadRequest();
    }

    return storage.UpdateStudentEmail(id, email) ?
        Results.Ok(storage.GetStudent(id)) : Results.NotFound();
});

app.MapDelete("/students/{id}", ([FromServices] StudentStorage storage, int id) =>
{
    return storage.DeleteStudent(id) ? Results.Ok() : Results.NotFound();
});

app.MapGet("/courses", ([FromServices] CourseStorage storage) =>
{
    var courses = storage.GetAllCourses();

    if (courses.Count <= 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(courses);
});

app.MapGet("/courses/{id}", ([FromServices] CourseStorage storage, int id) =>
{
    var course = storage.GetCourse(id);

    return course is not null ? Results.Ok(course) : Results.NotFound();
});

app.MapPost("/courses", ([FromServices] CourseStorage storage, Course course) =>
{
    if (course is null)
        return Results.BadRequest();

    return storage.CreateCourse(course) ? Results.Ok() : Results.Conflict();
});

app.MapDelete("/courses/{id}", ([FromServices] CourseStorage storage, int id) =>
{
    return storage.DeleteCourse(id) ? Results.Ok() : Results.NotFound();
});

//retires course. One way street!!!
app.MapMethods("/courses/{id}", new[] { "PATCH" },
    ([FromServices] CourseStorage storage, int id) =>
    {
        return storage.UpdateCourseStatus(id) ?
            Results.Ok(storage.GetCourse(id)) : Results.BadRequest("This is not a course or the course is already retired");
    });

app.Run();
