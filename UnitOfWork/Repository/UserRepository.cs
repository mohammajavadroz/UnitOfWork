using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.DatabaseContext;
using UnitOfWork.Data.InfraStructure;
using UnitOfWork.Entity.Models;

namespace UnitOfWork.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        DBContext _dbcontext;

        public UserRepository(DBContext dbcontext):base(dbcontext) 
        {
            _dbcontext = (dbcontext??(DBContext)_dbcontext);
        }
    }
}
