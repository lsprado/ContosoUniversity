using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.WebApplication.Data;
using ContosoUniversity.WebApplication.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ContosoUniversity.WebApplication.Pages.Courses
{
    public class EditModel : DepartmentNamePageModelModel
    {
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;
        private readonly IHttpClientFactory client;

        public EditModel(ContosoUniversity.WebApplication.Data.SchoolContext context, IHttpClientFactory client)
        {
            _context = context;
            this.client = client;
        }

        [BindProperty]
        public Models.APIViewModels.Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.CreateClient("client").GetStringAsync("api/Courses/" + id);
            Course = JsonConvert.DeserializeObject<Models.APIViewModels.Course>(response);

            if (Course == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateDepartmentsDropDownList(_context, Course.Department.ID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PutAsJsonAsync("api/Courses/" + id, Course);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            
            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, Course.Department.ID);
            return Page();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}