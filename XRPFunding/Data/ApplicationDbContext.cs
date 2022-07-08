using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace XRPFunding.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}