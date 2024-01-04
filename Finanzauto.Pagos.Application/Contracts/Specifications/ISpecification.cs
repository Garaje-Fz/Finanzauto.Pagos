namespace Finanzauto.Pagos.Application.Contracts.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
