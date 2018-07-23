using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.WebApplication.Data;
using ContosoUniversity.WebApplication.Models;

namespace ContosoUniversity.WebApplication.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.WebApplication.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Title");
        ViewData["StudentID"] = new SelectList(_context.Student, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollment.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}