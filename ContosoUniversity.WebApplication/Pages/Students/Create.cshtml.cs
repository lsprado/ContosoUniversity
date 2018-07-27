using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace ContosoUniversity.WebApplication.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;
        private readonly ILogger<CreateModel> logger;
        private readonly IHttpClientFactory client;

        public CreateModel(ContosoUniversity.WebApplication.Data.SchoolContext context, ILogger<CreateModel> logger, IHttpClientFactory client)
        {
            _context = context;
            this.logger = logger;
            this.client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.APIViewModels.Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyStudent = new Models.APIViewModels.Student();

            if (await TryUpdateModelAsync<Models.APIViewModels.Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.FirstName, s => s.LastName, s => s.EnrollmentDate))
            {
                var response = await client.CreateClient("client").PostAsJsonAsync("api/Students", emptyStudent);
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}