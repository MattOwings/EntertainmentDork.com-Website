using EntertainmentDorkWebpage.Data;
using EntertainmentDorkWebpage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntertainmentDorkWebpage.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<SubmissionForm> Submissions { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Submissions = _db.SubmissionForm;
        }
    }
}
