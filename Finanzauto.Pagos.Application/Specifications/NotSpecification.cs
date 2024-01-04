using Finanzauto.Pagos.Application.Contracts.Specifications;

namespace Finanzauto.Pagos.Application.Specifications
{
    public class NotSpecification<T> : ISpecification<T> where T : class
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return !_specification.IsSatisfiedBy(entity);
        }
    }
}
