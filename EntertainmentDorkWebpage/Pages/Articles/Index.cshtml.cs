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
    public class IndexModel : PageModel
    {
        private readonly EntertainmentDorkWebpage.Data.ApplicationDbContext _context;

        public IndexModel(EntertainmentDorkWebpage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MainArticles> MainArticles { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Articles != null)
            {
                MainArticles = await _context.Articles.ToListAsync();
            }
        }
    }
}
