using System.Linq.Expressions;

namespace Menofia_Portal.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; } = [];

        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<T, bool>> criteriaExp) => Criteria = criteriaExp;
    }
}
