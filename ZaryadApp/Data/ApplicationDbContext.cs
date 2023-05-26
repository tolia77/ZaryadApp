using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZaryadApp.Models;

namespace ZaryadApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ZaryadApp.Models.Review> Review { get; set; } = default!;
        public DbSet<ZaryadApp.Models.Station> Station { get; set; } = default!;
    }
}