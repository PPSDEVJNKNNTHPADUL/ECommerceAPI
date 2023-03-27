using ECommerce.Domain.Models;
using MediatR;

namespace ECommerce.Application.Commands
{
    public class UserCommand
    {
        public class AddUserCommand : IRequest<UserModel>
        {

            public string UserName { get; set; }
        }
    }
}
