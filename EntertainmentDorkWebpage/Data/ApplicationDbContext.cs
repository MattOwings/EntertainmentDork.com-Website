using EntertainmentDorkWebpage.Model;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentDorkWebpage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<SubmissionForm> SubmissionForm { get; set; }
        public DbSet<MainArticles> Articles { get; set; }
    }
}
