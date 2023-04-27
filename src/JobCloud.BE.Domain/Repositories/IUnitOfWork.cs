using JobCloud.BE.Domain.Models;

namespace JobCloud.BE.Domain.Repositories
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits all changes
        /// </summary>
        Task Commit();

        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        Task RejectChanges();

        Task Dispose();

        IRepository<T> GetGenericRepository<T>() where T : DomainEntity;
    }
}
