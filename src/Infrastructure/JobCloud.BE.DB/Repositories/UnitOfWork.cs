using JobCloud.BE.Domain.Models;
using JobCloud.BE.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobCloud.BE.DB.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobCloudDbContext _dbContext;

        public UnitOfWork(JobCloudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _dbContext.DisposeAsync();
        }

        public IRepository<T> GetGenericRepository<T>() where T : DomainEntity
        {
            return new Repository<T>(_dbContext);
        }

        public Task RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default:
                        continue;
                }
            }
            return Task.CompletedTask;
        }
    }
}
