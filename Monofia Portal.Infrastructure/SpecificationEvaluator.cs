using Menofia_Portal.Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Monofia_Portal.Infrastructure
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;
            if (specification.Criteria is { })
            {
                query = inputQuery.Where(specification.Criteria);
            }
            query = specification.Includes
               .Aggregate(query, (currentQuery, includeQuery) => currentQuery.Include(includeQuery));

            return query;
        }
    }
} 
