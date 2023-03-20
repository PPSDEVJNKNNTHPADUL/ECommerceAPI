using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class UserCommand
    {
        // Defines a class for adding a user, with a user name.
        // The command returns a UserModel object.
        public class AddUserCommand : IRequest<UserModel>
        {
            // The user name of the user to be added.
            public string UserName { get; set; }
        }
    }
}
