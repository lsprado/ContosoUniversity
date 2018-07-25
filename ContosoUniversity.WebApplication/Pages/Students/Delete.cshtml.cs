using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.WebApplication.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace ContosoUniversity.WebApplication.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private HttpClient client;
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;

        public DeleteModel(ContosoUniversity.WebApplication.Data.SchoolContext context)
        {
            _context = context;
            client = new HttpClient();
        }

        [BindProperty]
        public Models.APIViewModels.Student Student { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetStringAsync("http://localhost:30097/api/Students/" + id);
            Student = JsonConvert.DeserializeObject<Models.APIViewModels.Student>(response);

            if (Student == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var response = await client.DeleteAsync("http://localhost:30097/api/Students/" + id);

                if(response.IsSuccessStatusCode)
                    return RedirectToPage("./Index");
                else
                    return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}