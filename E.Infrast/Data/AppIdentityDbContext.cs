using E.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E.Infrast.Data
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppIdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppIdentityDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
