using Dapper;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interface;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DataContext dataContext, ILogger<UserRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<UserEntity> AddUser(UserEntity userEntity)
        {
            _logger.LogInformation("Create User in Database");
            try
            {
                _dataContext.Users.Add(userEntity);
                await _dataContext.SaveChangesAsync();

                _logger.LogInformation("Successfully added User: {@userEntity}", userEntity);
                return userEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Creating User Details:{ex}", ex);
                throw;
            }
        }

        public async Task<UserEntity> GetUserById(Guid userId)
        {
            _logger.LogInformation("Retrieve User By Id");
            try
            {
                var query = "SELECT * " +
                    "FROM Users " +
                    "WHERE UserId = @UserId";
                using var con = _dataContext.Database.GetDbConnection();
                var getUser = await con.QuerySingleOrDefaultAsync<UserEntity>(query, new { userId });

                return getUser;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Retrieving User Details:{ex}", ex);
                throw;
            }
        }
    }
}
