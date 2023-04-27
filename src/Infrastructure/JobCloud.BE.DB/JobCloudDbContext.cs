using JobCloud.BE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace JobCloud.BE.DB
{
    public class JobCloudDbContext : DbContext
    {
        public JobCloudDbContext(DbContextOptions<JobCloudDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<DomainEntity>())
            {
                entry.Entity.ModfiedOn = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedOn = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        DbSet<Offer> Offers { get; set; }
        DbSet<Technology> Technologies { get; set; }
    }
}
