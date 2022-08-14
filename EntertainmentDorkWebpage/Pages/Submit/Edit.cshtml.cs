using EntertainmentDorkWebpage.Data;
using EntertainmentDorkWebpage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntertainmentDorkWebpage.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public SubmissionForm Submission { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Submission = _db.SubmissionForm.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            /*if (!Submission.Email.Contains("@"))
            {
                ModelState.AddModelError(String.Empty, "Email is invalid");
            }*/ // validate email
            if (ModelState.IsValid)
            {
                _db.SubmissionForm.Update(Submission);
                await _db.SaveChangesAsync();
                TempData["success"] = "Submission edited successfully!";

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
