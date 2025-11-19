using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Domain.User;
using UnitOfWork.Infrastructure.EfCore;
using UnitOfWork.Shared.InfraStructure.Repository;

namespace UnitOfWork.Infrastructure.User
{
    public class UserRepository : EfRepository<ShopDbContext, Domain.User.User, Guid> , IUserRepository
    {
        public UserRepository(ShopDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
