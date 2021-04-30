using Microsoft.EntityFrameworkCore;

namespace Nouran.Infrastructure.Persistence
{
    public class NouranDbContext : DbContext
    {
        public NouranDbContext(DbContextOptions<NouranDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}