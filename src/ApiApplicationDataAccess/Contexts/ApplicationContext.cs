using ApiApplicationDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiApplicationDataAccess.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Currency> Currency => Set<Currency>();
        public DbSet<ExchangeRate> ExchangeRate => Set<ExchangeRate>();

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Currency.db");
        }
    }
}
