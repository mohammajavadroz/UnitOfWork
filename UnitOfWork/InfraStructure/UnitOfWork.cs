using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.DatabaseContext;
using UnitOfWork.Data.Repository;

namespace UnitOfWork.Data.InfraStructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DBContext, new()
    {
       protected readonly DBContext _dbcontext;

        public UnitOfWork()
        {
            _dbcontext = new TContext();
        }

        public void Commit()
        {
            _dbcontext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
           return await _dbcontext.SaveChangesAsync();
        }

         bool Disposed = false;

        private UserRepository userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_dbcontext);
                }
                return userRepository;
            }
        }

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
    }
}
