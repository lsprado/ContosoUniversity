using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.WebApplication.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace ContosoUniversity.WebApplication.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;
        private readonly ILogger<EditModel> logger;
        private readonly IHttpClientFactory client;

        public EditModel(ContosoUniversity.WebApplication.Data.SchoolContext context, ILogger<EditModel> logger, IHttpClientFactory client)
        {
            _context = context;
            this.logger = logger;
            this.client = client;
        }

        [BindProperty]
        public Models.APIViewModels.Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.CreateClient("client").GetStringAsync("api/Students/" + id);
            Student = JsonConvert.DeserializeObject<Models.APIViewModels.Student>(response);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                HttpResponseMessage response = await client.CreateClient("client").PutAsJsonAsync("api/Students/" + Student.id, Student);

                if (!response.IsSuccessStatusCode)
                    logger.LogDebug(response.ToString());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
