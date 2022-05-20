using Microsoft.EntityFrameworkCore;
using WestCoastEducation.Shared;

namespace WestCoastEducation.Server.DAL
{
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public CourseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
