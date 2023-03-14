using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repository
{
    public class UserAddRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserAddRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<UserModel> AddUser(UserModel userName)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserModelById(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
