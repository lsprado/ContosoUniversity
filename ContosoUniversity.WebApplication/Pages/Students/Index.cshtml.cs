using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Newtonsoft.Json;

namespace ContosoUniversity.WebApplication.Pages.Students
{
    public class IndexModel : PageModel
    {
        
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;
        private readonly IHttpClientFactory client;

        public string CurrentFilter { get; set; }
        
        public IndexModel(ContosoUniversity.WebApplication.Data.SchoolContext context, IHttpClientFactory client)
        {
            _context = context;
            this.client = client;
        }

        public Models.APIViewModels.StudentResult Student { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id, string SearchString)
        {
            if (string.IsNullOrEmpty(SearchString))
            {
                var response = await client.CreateClient("client").GetStringAsync("api/Students");
                Student = JsonConvert.DeserializeObject<Models.APIViewModels.StudentResult>(response);
            }
            else
            {
                var response = await client.CreateClient("client").GetStringAsync("api/Students/Search?name=" + SearchString);
                Student = JsonConvert.DeserializeObject<Models.APIViewModels.StudentResult>(response);
            }
            return Page();
        }
    }
}