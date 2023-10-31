using Microsoft.EntityFrameworkCore;
using TechsnovelTechnicalTask.Domain.Entities;

namespace TechsnovelTechnicalTask.Application.Interfaces.Contexts
{
    public interface ISqlDataBaseContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
