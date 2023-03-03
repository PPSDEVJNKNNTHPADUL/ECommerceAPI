using ECommerce.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validation
{
    public class UserValidator
    {
        public class UserValidation : AbstractValidator<UserCommand.AddUserCommand>
        {
            public UserValidation()
            {
                RuleFor(u => u.UserName)
                    .NotEmpty().WithMessage("Username is required.")
                    .Length(4, 10).WithMessage("Username must be between 4 and 10 characters.")
                    .NotNull().WithMessage("Username cannot be null.");
            }
        }
    }
}
