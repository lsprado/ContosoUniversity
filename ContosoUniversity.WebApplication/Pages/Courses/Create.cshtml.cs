using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.WebApplication.Data;
using ContosoUniversity.WebApplication.Models;
using System.Net.Http;

namespace ContosoUniversity.WebApplication.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModelModel
    {
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;
        private readonly IHttpClientFactory client;

        public CreateModel(ContosoUniversity.WebApplication.Data.SchoolContext context, IHttpClientFactory client)
        {
            _context = context;
            this.client = client;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");
            return Page();
        }

        [BindProperty]
        public Models.APIViewModels.Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PostAsJsonAsync("api/Courses", Course);
            return RedirectToPage("./Index");
        }
    }
}