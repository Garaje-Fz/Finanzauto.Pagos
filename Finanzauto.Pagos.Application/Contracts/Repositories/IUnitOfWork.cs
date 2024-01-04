namespace Finanzauto.Pagos.Application.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
        IRepository<T> GetRepository<T>() where T : class;
    }
}
