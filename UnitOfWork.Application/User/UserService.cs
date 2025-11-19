using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Contracts.User;
using UnitOfWork.Domain.User;
using UnitOfWork.Infrastructure.EfCore;
using UnitOfWork.Shared.InfraStructure.UnitOfWork;

namespace UnitOfWork.Application.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkManager<ShopDbContext> _unitOfWorkManager;
        public UserService(IUserRepository userRepository, IUnitOfWorkManager<ShopDbContext> unitOfWorkManager)
        {
            _userRepository = userRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task CreateUserAsync(string name, string lastName)
        {
            try
            {
                await _unitOfWorkManager.BeginAsync();
                var newUser = new UnitOfWork.Domain.User.User()
                {
                    Name = name,
                    LastName = lastName
                };
                await _userRepository.InsertAsync(newUser);

                //Insert Product
                //Insert Order

                await _unitOfWorkManager.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWorkManager.RollBackAsync();  
            }
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var users = await (_userRepository.GetQueryable())
                .Select(u => new UserDto()
                {
                    Name = u.Name,
                    LastName = u.LastName
                }).ToListAsync();
            return users;
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await (_userRepository.GetQueryable())
                 .Where(u => u.Id == id)
                .Select(u => new UserDto()
                {
                    Name = u.Name,
                    LastName = u.LastName
                }).FirstOrDefaultAsync();
            return user;
        }

    }
}
