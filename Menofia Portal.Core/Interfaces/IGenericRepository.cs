using System.Linq.Expressions;

namespace Menofia_Portal.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Criteria = null!, params Expression<Func<T, object>>[] Includes);
        public Task<T> GetByIdAsync(Expression<Func<T, bool>> Criteria = null!, params Expression<Func<T, object>>[] Includes);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }
}
