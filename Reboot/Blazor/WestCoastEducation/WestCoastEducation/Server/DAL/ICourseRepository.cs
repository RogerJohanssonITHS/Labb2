﻿using WestCoastEducation.Shared;

namespace ControllerRestDemo.Server.DAL;

public interface ICourseRepository : IDisposable
{
    void Create(Course course);
    ICollection<Course> GetAllCourses();
    Course? GetCourse(int id);
    bool UpdateCourse(int id);
    bool DeleteCourse(int id);
}