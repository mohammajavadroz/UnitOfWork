using Microsoft.EntityFrameworkCore;

namespace UnitOfWork.Shared.InfraStructure.UnitOfWork
{
    public interface IUnitOfWorkManager<TContext> : IDisposable where TContext : DbContext
    {
        Task BeginAsync();
        void Commit();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
