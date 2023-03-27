using UnitTestMoqFinal.Models;

namespace UnitTestMoqFinal.Service
{
    public interface IUserService
    {
        public IEnumerable<User> GetProductList();
        public User GetUserById(Guid userId);
        public User AddUser(User user);
        public User UpdateUser(User user);
        public bool DeleteUser(Guid userId);
    }
}
