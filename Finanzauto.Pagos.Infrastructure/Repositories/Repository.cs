using Finanzauto.Pagos.Application.Contracts.Repositories;
using Finanzauto.Pagos.Application.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finanzauto.Pagos.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        private List<Expression<Func<T, object>>> _includeExpressions = new();
        private List<string> _includeStrings = new();
        private Func<IQueryable<T>, IOrderedQueryable<T>> _orderBy;
        private bool _enableTracking;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(T entity)
        {
            _context.Set<T>().AddRange(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            var entity = ConfigureQuery(predicate);
            return await entity.ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(ExpressionSpecification<T> specification)
        {
            var entity = ConfigureQuery(specification.Expression);
            return await entity.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            var entity = ConfigureQuery(predicate);
            return await entity.FirstAsync();
        }

        public async Task<T> FindOne(ExpressionSpecification<T> specification)
        {
            var entity = ConfigureQuery(specification.Expression);
            return await entity.FirstAsync();
        }

        public IRepository<T> Include(Expression<Func<T, object>> includeExpression)
        {
            _includeExpressions.Add(includeExpression);
            return this;
        }

        public IRepository<T> Include(string includeString)
        {
            _includeStrings.Add(includeString);
            return this;
        }

        public IRepository<T> OderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public IRepository<T> Tracking(bool enableTraking)
        {
            _enableTracking = enableTraking;
            return this;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        private IQueryable<T> ConfigureQuery(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>();
            if (_enableTracking) query = query.AsNoTracking();
            if (_includeExpressions != null) query = _includeExpressions.Aggregate(query, (current, include) => current.Include(include));
            if (_includeStrings != null) query = _includeStrings.Aggregate(query, (current, include) => current.Include(include));
            if (predicate != null) query = query.Where(predicate);
            if (_orderBy != null)
                return _orderBy(query);
            return query;
        }

    }
}
