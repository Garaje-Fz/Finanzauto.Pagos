using Finanzauto.Pagos.Application.Contracts.Specifications;
using System.Linq.Expressions;

namespace Finanzauto.Pagos.Application.Specifications
{
    public abstract class ExpressionSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Expression { get; }

        private Func<T, bool> _expressionFunc;
        private Func<T, bool> ExpressionFunc => _expressionFunc ?? (_expressionFunc = Expression.Compile());

        protected ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            bool result = ExpressionFunc(entity);
            return result;
        }
    }
}
