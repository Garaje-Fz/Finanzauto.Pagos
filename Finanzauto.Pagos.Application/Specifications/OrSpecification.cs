using Finanzauto.Pagos.Application.Contracts.Specifications;

namespace Finanzauto.Pagos.Application.Specifications
{
    public class OrSpecification<T> : ISpecification<T> where T : class
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return _left.IsSatisfiedBy(entity) || _right.IsSatisfiedBy(entity);
        }
    }
}
