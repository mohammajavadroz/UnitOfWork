using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Shared.InfraStructure.Repository
{
    public interface IRepository<TEntity, Tkey> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Tkey Id);
        TEntity GetById(Tkey Id);
        List<TEntity> GetAll();
        //async functions

        IQueryable<TEntity> GetQueryable();
        Task InsertAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Tkey Id);
    }
}
