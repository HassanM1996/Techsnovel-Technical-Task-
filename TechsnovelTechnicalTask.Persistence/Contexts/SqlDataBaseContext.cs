using Microsoft.EntityFrameworkCore;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Domain.Entities;

namespace TechsnovelTechnicalTask.Persistence.Contexts
{
    public class DataBaseContext : DbContext, ISqlDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<UserAccount>().HasIndex(x => x.Email).IsUnique();


            ApplyQueryFilter(modelBuilder);
        }
        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<UserAccount>().HasQueryFilter(t => !t.IsDeleted);

        }
    }
}
