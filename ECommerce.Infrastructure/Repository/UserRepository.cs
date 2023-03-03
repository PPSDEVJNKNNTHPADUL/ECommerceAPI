using AutoMapper;
using Dapper;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DataContext dataContext, IMapper mapper, ILogger<UserRepository> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UserModel> AddUser(UserModel userName)
        {
            _logger.LogInformation("Create User in Database");
            try
            {
                var userMapper = _mapper.Map<UserEntity>(userName);
                _dataContext.Users.Add(userMapper);
                await _dataContext.SaveChangesAsync();

                var createdUser = _mapper.Map<UserModel>(userMapper);

                _logger.LogInformation("Successfully added User: {@createdUser}", createdUser);
                return createdUser;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Creating User Details:{ex}", ex);
                throw;
            }
        }


        public async Task<UserModel> GetUserModelById(Guid userId)
        {
            _logger.LogInformation("Retrieve User By Id");
            try
            {
                var query = "SELECT * " +
                    "FROM Users " +
                    "WHERE UserId = @UserId";
                using var con = _dataContext.Database.GetDbConnection();
                var getUser = await con.QuerySingleOrDefaultAsync<UserModel>(query, new { userId });
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
