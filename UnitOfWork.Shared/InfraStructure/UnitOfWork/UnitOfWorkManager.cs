using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace UnitOfWork.Shared.InfraStructure.UnitOfWork
{
    public class UnitOfWorkManager<TContext> : IUnitOfWorkManager<TContext> where TContext : DbContext
    {
        protected readonly TContext _dbcontext;
        private IDbContextTransaction _transaction;
        public UnitOfWorkManager(TContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Commit()
        {
            _dbcontext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbcontext.SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        bool Disposed = false;

        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposed)
            {
                if (Disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task BeginAsync()
        {
            _transaction = await _dbcontext.Database.BeginTransactionAsync();
        }

        public async Task RollBackAsync()
        {
            await _transaction.RollbackAsync();
        }

      
    }
}
