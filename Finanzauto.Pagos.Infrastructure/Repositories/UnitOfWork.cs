using Finanzauto.Pagos.Application.Contracts.Repositories;
using Finanzauto.Pagos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Pagos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClientsDbContext _context;

        public UnitOfWork(ClientsDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransaction()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Rollback()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
