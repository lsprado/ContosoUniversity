using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Pages.Instructors
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public EditModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        [BindProperty]
        public Models.APIViewModels.Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.CreateClient("client").GetStringAsync("api/Instructors/" + id);
            Instructor = JsonConvert.DeserializeObject<Models.APIViewModels.Instructor>(response);

            if (Instructor == null)
            {
                return NotFound();
            }

            //PopulateAssignedCourseData(_context, Instructor);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PutAsJsonAsync("api/Instructors/" + id, Instructor);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            //UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate);
            //PopulateAssignedCourseData(_context, instructorToUpdate);
            return Page();

        }
    }
}
