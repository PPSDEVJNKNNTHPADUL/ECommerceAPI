using ECommerce.Domain.Entities;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interface
{

    public interface IUserRepository
    {

        Task<UserEntity> AddUser(UserEntity userName);

        Task<UserEntity> GetUserById(Guid userId);

    }
}
