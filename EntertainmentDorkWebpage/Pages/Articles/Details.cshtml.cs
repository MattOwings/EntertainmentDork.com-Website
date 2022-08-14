using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntertainmentDorkWebpage.Data;
using EntertainmentDorkWebpage.Model;

namespace EntertainmentDorkWebpage.Pages.Articles
{
    public class DetailsModel : PageModel
    {
        private readonly EntertainmentDorkWebpage.Data.ApplicationDbContext _context;

        public DetailsModel(EntertainmentDorkWebpage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public MainArticles MainArticles { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var mainarticles = await _context.Articles.FirstOrDefaultAsync(m => m.Id == id);
            if (mainarticles == null)
            {
                return NotFound();
            }
            else 
            {
                MainArticles = mainarticles;
            }
            return Page();
        }
    }
}
