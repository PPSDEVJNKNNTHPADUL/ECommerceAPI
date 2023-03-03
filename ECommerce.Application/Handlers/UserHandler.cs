using ECommerce.Application.Commands;
using ECommerce.Application.Queries;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class UserHandler
    {
        public class AddUserCommandHandler : IRequestHandler<UserCommand.AddUserCommand, UserModel>
        {
            private readonly IUserRepository _userRepository;

            public AddUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<UserModel> Handle(UserCommand.AddUserCommand command, CancellationToken cancellationToken)
            {
                var userModel = new UserModel
                {
                    UserName = command.UserName
                };
                var createdUser = await _userRepository.AddUser(userModel);
                return createdUser;
            }
        }

        public class GetUserByIdQueryHandler : IRequestHandler<UserQuery.GetUserByIdQuery, UserModel>
        {
            private readonly IUserRepository _userRepository;

            public GetUserByIdQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<UserModel> Handle(UserQuery.GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetUserModelById(request.UserId);
                return user;
            }
        }
    }
}
