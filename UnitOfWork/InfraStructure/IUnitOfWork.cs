using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.DatabaseContext;
using UnitOfWork.Data.Repository;

namespace UnitOfWork.Data.InfraStructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DBContext
    {
        UserRepository UserRepository { get; }
        void Commit();

        Task<int> CommitAsync();
    }
}
