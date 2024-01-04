using Finanzauto.Pagos.Application.Contracts.Specifications;

namespace Finanzauto.Pagos.Application.Specifications
{
    public static class SpecificationExtensions
    {
        public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right) where T : class
        {
            return new AndSpecification<T>(left, right);
        }

        public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right) where T : class
        {
            return new OrSpecification<T>(left, right);
        }

        public static ISpecification<T> Not<T>(this ISpecification<T> specification) where T : class
        {
            return new NotSpecification<T>(specification);
        }
    }
}
