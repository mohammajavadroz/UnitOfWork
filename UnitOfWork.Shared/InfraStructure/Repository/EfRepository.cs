using Microsoft.EntityFrameworkCore;

namespace UnitOfWork.Shared.InfraStructure.Repository
{

    public class EfRepository<TContext, TEntity, Tkey> :
        IRepository<TEntity, Tkey> 
        where TContext : DbContext
        where TEntity : class
    {
        private readonly TContext _dbcontext;

        public EfRepository(TContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        private DbSet<TEntity> Dbset
        {
            get { return _dbcontext.Set<TEntity>(); }
        }

        public void Delete(Tkey Id)
        {
            var Entity = GetById(Id);
            if (Entity == null)
            {
                throw new ArgumentException("no entity");
            }
            Dbset.Remove(Entity);
        }



        public List<TEntity> GetAll()
        {
            return Dbset.ToList();

        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Dbset.ToListAsync();
        }

        public TEntity GetById(Tkey Id)
        {
            return Dbset.Find(Id);
        }

        public async Task<TEntity> GetByIdAsync(Tkey Id)
        {
            return await Dbset.FindAsync(Id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return Dbset.AsQueryable();
        }

        public void Insert(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await Dbset.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            Dbset.Update(entity);

        }


    }
}
