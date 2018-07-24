using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Newtonsoft.Json;

namespace ContosoUniversity.WebApplication.Pages.Students
{
    public class IndexModel : PageModel
    {
        private HttpClient client;
        private readonly ContosoUniversity.WebApplication.Data.SchoolContext _context;

        public string CurrentFilter { get; set; }
        
        public IndexModel(ContosoUniversity.WebApplication.Data.SchoolContext context)
        {
            _context = context;
            client = new HttpClient();
        }

        public Models.APIViewModels.StudentResult Student { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var response = await client.GetStringAsync("http://localhost:30097/api/Students");
            Student = JsonConvert.DeserializeObject<Models.APIViewModels.StudentResult>(response);
            return Page();
        }
    }
}