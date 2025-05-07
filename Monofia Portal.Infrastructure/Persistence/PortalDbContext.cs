using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Monofia_Portal.Infrastructure.Persistence
{
    public class PortalDbContext(DbContextOptions<PortalDbContext> options) : DbContext(options)
    {
        public DbSet<PortalNews> News { get; set; }
        public DbSet<NewsTranslation> NewsTranslation { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
