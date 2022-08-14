using EntertainmentDorkWebpage.Data;
using EntertainmentDorkWebpage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntertainmentDorkWebpage.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public SubmissionForm Submission { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Submission = _db.SubmissionForm.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
                var submissionFromDb = _db.SubmissionForm.Find(Submission.Id);
                if (submissionFromDb != null)
                {
                    _db.Remove(submissionFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Submission deleted successfully!";

                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
