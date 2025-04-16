using Menofia_Portal.Core.Interfaces;
using Menofia_Portal.Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Monofia_Portal.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PortalDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(PortalDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(ISpecification<T> specification)
        {
            return await ApplyingSpecification(specification).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(ISpecification<T> specification)
        {
            return await ApplyingSpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplyingSpecification(ISpecification<T> specification) => SpecificationEvaluator<T>
            .GetQuery(_dbSet, specification);
    }
}
