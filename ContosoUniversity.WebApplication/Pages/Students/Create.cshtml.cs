using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.IO;

namespace ContosoUniversity.WebApplication.Pages.Students
{
    public class CreateModel : PageModel
    { 
        private readonly ILogger<CreateModel> logger;
        private readonly IHttpClientFactory client;

        public CreateModel(ILogger<CreateModel> logger, IHttpClientFactory client)
        {
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
                s => s.FirstName, s => s.LastName, s => s.EnrollmentDate, s => s.Photo))
            {

                //Converte a imagem para Array de Bytes
                Byte[] arquivo = null;
                using (var ms = new MemoryStream())
                {
                    emptyStudent.Photo.CopyTo(ms);
                    arquivo = ms.ToArray();
                }

                //var response = await client.CreateClient("client").PostAsJsonAsync("api/Students", emptyStudent);

                var response = await client.CreateClient("client").PostAsJsonAsync("api/Students", new { Id = emptyStudent.Id, LastName = emptyStudent.LastName, FirstName = emptyStudent.FirstName, EnrollmentDate = emptyStudent.EnrollmentDate, Photo = arquivo });

                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}