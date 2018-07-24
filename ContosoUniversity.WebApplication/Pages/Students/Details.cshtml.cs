using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.WebApplication.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ContosoUniversity.WebApplication.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private HttpClient client;
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversity.WebApplication.Data.SchoolContext context)
        {
            _context = context;
            client = new HttpClient();
        }

        public Models.APIViewModels.Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

            return Page();
        }
    }
}
