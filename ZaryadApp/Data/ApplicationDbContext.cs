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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Review)
                .WithOne(r => r.ApplicationUser)
                .HasForeignKey<Review>(r => r.ApplicationUserId);
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Settings)
                .WithOne(r => r.ApplicationUser)
                .HasForeignKey(r => r.ApplicationUserId);
        }
        public DbSet<Settings> Settings { get; set; } = default!;
        public DbSet<Review> Review { get; set; } = default!;
        public DbSet<Station> Station { get; set; } = default!;
        public DbSet<ZaryadApp.Models.Post> Post { get; set; } = default!;
    }
}