using Menofia_Portal.Core.Specification;

namespace Menofia_Portal.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync(ISpecification<T> specification);
        public Task<T> GetByIdAsync(ISpecification<T> specification);
    }
}
