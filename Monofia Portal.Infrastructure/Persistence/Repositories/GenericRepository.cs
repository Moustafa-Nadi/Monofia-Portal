using Menofia_Portal.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Criteria = null!, params Expression<Func<T, object>>[] Includes)
        {
            var query = _dbSet.AsQueryable();
            if (Criteria is not null)
                query = query.Where(Criteria);

            if (Includes is { } && Includes.Length > 0)
            {
                foreach (var include in Includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> Criteria = null!, params Expression<Func<T, object>>[] Includes)
        {
            var query = _dbSet.AsQueryable();

            if (Criteria is not null)
                query = query.Where(Criteria);

            if (Includes is { } && Includes.Length > 0)
            {
                foreach (var include in Includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await SaveAsync();
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();


    }
}
