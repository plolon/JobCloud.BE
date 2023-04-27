using JobCloud.BE.Domain.Models;
using JobCloud.BE.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobCloud.BE.DB.Repositories
{
    public class Repository<T> : IRepository<T> where T : DomainEntity
    {
        private readonly JobCloudDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(JobCloudDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetManyAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? top = null,
            int? skip = null,
            params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (filter is not null)
                query = query.Where(filter);

            if (includeProperties.Length > 0)
                query = includeProperties.Aggregate(query, (theQuery, theInclude) => theQuery.Include(theInclude));

            if (orderBy is not null)
                query = orderBy(query);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (top.HasValue)
                query = query.Take(top.Value);

            return await query.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }


        public Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
        public Task DeleteManyAsync(Expression<Func<T, bool>> filter)
        {
            var entities = _dbSet.Where(filter);
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }
    }
}
