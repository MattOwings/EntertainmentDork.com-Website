using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntertainmentDorkWebpage.Data;
using EntertainmentDorkWebpage.Model;

namespace EntertainmentDorkWebpage.Pages.Articles
{
    public class EditModel : PageModel
    {
        private readonly EntertainmentDorkWebpage.Data.ApplicationDbContext _context;

        public EditModel(EntertainmentDorkWebpage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MainArticles MainArticles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var mainarticles =  await _context.Articles.FirstOrDefaultAsync(m => m.Id == id);
            if (mainarticles == null)
            {
                return NotFound();
            }
            MainArticles = mainarticles;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MainArticles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainArticlesExists(MainArticles.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MainArticlesExists(int id)
        {
          return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
