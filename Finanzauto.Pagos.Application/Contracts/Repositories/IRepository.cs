using Finanzauto.Pagos.Application.Specifications;
using System.Linq.Expressions;

namespace Finanzauto.Pagos.Application.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Find(ExpressionSpecification<T> specification);
        Task<T> FindOne(Expression<Func<T, bool>> predicate);
        Task<T> FindOne(ExpressionSpecification<T> specification);
        IRepository<T> Include(Expression<Func<T, object>> includeExpression);
        IRepository<T> Include(string includeString);
        IRepository<T> Tracking(bool enableTraking);
        IRepository<T> OderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        void Add(T entity);
        void AddRange(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
