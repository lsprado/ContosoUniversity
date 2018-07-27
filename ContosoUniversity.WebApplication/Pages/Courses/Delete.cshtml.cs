using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.WebApplication.Data;
using ContosoUniversity.WebApplication.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ContosoUniversity.WebApplication.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public DeleteModel(IHttpClientFactory client)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.CreateClient("client").DeleteAsync("api/Courses/" + id);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("./Index");
            else
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            
        }
    }
}
