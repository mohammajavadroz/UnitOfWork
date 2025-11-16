using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Data.InfraStructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        

        void Delete(object Id);


        TEntity GetById(object Id);

        List<TEntity> GetAll();

       
        //async functions
        Task InsertAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(object Id);

        

        


    }
}
