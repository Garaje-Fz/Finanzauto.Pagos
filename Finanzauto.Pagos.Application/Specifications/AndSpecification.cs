using Finanzauto.Pagos.Application.Contracts.Specifications;

namespace Finanzauto.Pagos.Application.Specifications
{
    public class AndSpecification<T> : ISpecification<T> where T : class
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return _left.IsSatisfiedBy(entity) && _right.IsSatisfiedBy(entity);
        }
    }
}
