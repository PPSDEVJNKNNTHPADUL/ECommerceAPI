using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{
    public interface IUserRepository
    {
        Task<UserModel> AddUser(UserModel userName);
        Task<UserModel> GetUserModelById(Guid userId);
    }
}
