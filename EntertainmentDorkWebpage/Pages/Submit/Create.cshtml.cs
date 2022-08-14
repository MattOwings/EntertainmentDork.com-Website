using EntertainmentDorkWebpage.Data;
using EntertainmentDorkWebpage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntertainmentDorkWebpage.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public SubmissionForm Submission { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            /*if (!Submission.Email.Contains("@"))
            {
                ModelState.AddModelError(String.Empty, "Email is invalid");
            }*/ // validate email
            if (ModelState.IsValid)
            {
                await _db.SubmissionForm.AddAsync(Submission);
                await _db.SaveChangesAsync();
                TempData["success"] = "Submission created successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
