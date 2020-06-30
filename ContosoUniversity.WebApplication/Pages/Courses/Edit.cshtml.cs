using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public EditModel(IHttpClientFactory client)
        {
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
            var response_dep = await client.CreateClient("client").GetStringAsync("api/Departments");
            var dep = JsonConvert.DeserializeObject<Models.APIViewModels.DepartmentResult>(response_dep);
            ViewData["DepartmentID"] = new SelectList(dep.Departments, "ID", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PutAsJsonAsync("api/Courses/" + id, Course);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}