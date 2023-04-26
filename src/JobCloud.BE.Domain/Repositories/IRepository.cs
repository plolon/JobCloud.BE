using JobCloud.BE.Domain.Models;
using System.Linq.Expressions;

namespace JobCloud.BE.Domain.Repositories
{
    public interface IRepository<T> where T : DomainEntity
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteManyAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetManyAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? top = null,
            int? skip = null,
            params string[] includeProperties);
        Task UpdateAsync(T entity);
    }
}
