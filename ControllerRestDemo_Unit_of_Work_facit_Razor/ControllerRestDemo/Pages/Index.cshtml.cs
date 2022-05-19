using ControllerRestDemo.DAL;
using ControllerRestDemo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_from_this.Pages
{
    public class IndexModel : PageModel
    {
        private StudentContext _studentContext;

        [BindProperty]
        public Course course { get; set; }

        public IndexModel(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void OnGet()
        {
            course = new Course();
        }

        public void OnPost()
        {
            _studentContext.Courses.Add(course);
            _studentContext.SaveChanges();
        }
    }
}