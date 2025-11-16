using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.DatabaseContext;
using UnitOfWork.Entity.Models;

namespace UnitOfWork.Data.InfraStructure
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
         DBContext _dbcontext;

        public Repository(DBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        private DbSet<TEntity> dbset 
        {
            get {  return _dbcontext.Set<TEntity>();}
        }
        

        public void Delete(object Id)
        {
            var Entity = GetById(Id);
            if (Entity == null)
            {
                throw new ArgumentException("no entity");
            }
            dbset.Remove(Entity);
        }

       

        public List<TEntity> GetAll()
        {
           return dbset.ToList();
            
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public TEntity GetById(object Id)
        {
           return dbset.Find(Id);
        }

        public async Task<TEntity> GetByIdAsync(object Id)
        {
            return await dbset.FindAsync(Id);
        }

        

      

        public void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await dbset.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            dbset.Update(entity);

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        
    }
}
