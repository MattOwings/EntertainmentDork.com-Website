using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EntertainmentDorkWebpage.Data;
using EntertainmentDorkWebpage.Model;

namespace EntertainmentDorkWebpage.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly EntertainmentDorkWebpage.Data.ApplicationDbContext _context;

        public CreateModel(EntertainmentDorkWebpage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MainArticles MainArticles { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Articles == null || MainArticles == null)
            {
                return Page();
            }

            _context.Articles.Add(MainArticles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
