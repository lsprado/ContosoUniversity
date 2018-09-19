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
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public IndexModel(IHttpClientFactory client)
        {
            this.client = client;
        }

        public Models.APIViewModels.NoticiaResult Noticia { get; set; }

        public async Task OnGetAsync(int? id, int? courseID)
        {
            var response = await client.CreateClient("client").GetStringAsync("api/Noticias");
            Noticia = JsonConvert.DeserializeObject<Models.APIViewModels.NoticiaResult>(response);
        }
    }
}