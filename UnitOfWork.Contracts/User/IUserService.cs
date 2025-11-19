using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Contracts.User
{
    public interface IUserService
    {
        Task CreateUserAsync(string name , string lastName);
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto> GetByIdAsync(Guid id);

    }
}
