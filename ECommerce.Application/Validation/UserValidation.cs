using ECommerce.Application.Commands;
using FluentValidation;

namespace ECommerce.Application.Validation
{
    public class UserValidation : AbstractValidator<AddUserCommand>
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
