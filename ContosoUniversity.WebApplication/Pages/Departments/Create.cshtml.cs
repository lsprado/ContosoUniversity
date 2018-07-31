using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoUniversity.WebApplication.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public CreateModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        public async Task<IActionResult> OnGet()
        {
            var response = await client.CreateClient("client").GetStringAsync("api/Instructors");
            var i = JsonConvert.DeserializeObject<Models.APIViewModels.InstructorResult>(response);
            ViewData["InstructorID"] = new SelectList(i.Instructors, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Models.APIViewModels.Department Department { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PostAsJsonAsync("api/Departments", Department);

            return RedirectToPage("./Index");
        }
    }
}