using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Pages.Instructors
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public CreateModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        public IActionResult OnGet()
        {
            //var instructor = new Instructor();
            //instructor.CourseAssignments = new List<CourseAssignment>();

            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            //PopulateAssignedCourseData(_context, instructor);
            return Page();
        }

        [BindProperty]
        public Models.APIViewModels.Instructor Instructor { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PostAsJsonAsync("api/Instructors", Instructor);
            return RedirectToPage("./Index");
        }
    }

}