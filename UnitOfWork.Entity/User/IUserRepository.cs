using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Shared.InfraStructure.Repository;

namespace UnitOfWork.Domain.User
{
    public interface IUserRepository : IRepository<User,Guid>
    {
    }
}
