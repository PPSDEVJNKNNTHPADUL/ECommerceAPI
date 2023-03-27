using UnitTestMoqFinal.Data;
using UnitTestMoqFinal.Models;

namespace UnitTestMoqFinal.Service
{
    public class UserService : IUserService
    {
        private readonly DbContextClass _dbContext;

        public UserService(DbContextClass dbContext)
        {
            _dbContext=dbContext;
        }

        public User AddUser(User user)
        {
            var result = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetProductList()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
