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

namespace ContosoUniversity.WebApplication.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public EditModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        [BindProperty]
        public Models.APIViewModels.Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.CreateClient("client").GetStringAsync("api/Departments/" + id);
            Department = JsonConvert.DeserializeObject<Models.APIViewModels.Department>(response);

            if (Department == null)
            {
                return NotFound();
            }

            var responseI = await client.CreateClient("client").GetStringAsync("api/Instructors");
            var i = JsonConvert.DeserializeObject<Models.APIViewModels.InstructorResult>(responseI);
            ViewData["InstructorID"] = new SelectList(i.Instructors, "ID", "FullName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await client.CreateClient("client").PutAsJsonAsync("api/Departments/" + id, Department);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
