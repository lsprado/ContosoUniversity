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
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory client;

        public IndexModel(IHttpClientFactory client)
        { 
            this.client = client;
        }

        public Models.APIViewModels.CoursesResult Course { get; set; }

        public async Task OnGetAsync()
        {
            var response = await client.CreateClient("client").GetStringAsync("api/Courses");
            Course = JsonConvert.DeserializeObject<Models.APIViewModels.CoursesResult>(response);
        }
    }
}