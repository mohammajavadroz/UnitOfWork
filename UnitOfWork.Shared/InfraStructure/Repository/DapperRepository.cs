
namespace UnitOfWork.Shared.InfraStructure.Repository
{
    public class DapperRepository<TEntity, Tkey> : IRepository<TEntity, Tkey>
        where TEntity : class
    {
        public void Delete(Tkey Id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Tkey Id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Tkey Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
