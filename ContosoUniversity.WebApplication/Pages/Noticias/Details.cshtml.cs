using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ContosoUniversity.WebApplication.Pages.Noticias
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public DetailsModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        public Models.APIViewModels.Noticia Noticia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.CreateClient("client").GetStringAsync("api/Noticias/" + id);
            Noticia = JsonConvert.DeserializeObject<Models.APIViewModels.Noticia>(response);

            if (Noticia == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}