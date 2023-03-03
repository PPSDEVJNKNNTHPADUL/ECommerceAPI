using AutoMapper;
using ECommerce.Application.Commands;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var userModel = new UserModel
            {
                UserName = command.UserName
            };
            var createdUser = await _userRepository.AddUser(userModel);
            return createdUser;
        }
    }
}
