using ECommerce.Application.Commands;
using FluentValidation;

namespace ECommerce.Application.Validation
{
    public class CheckoutValidation : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutValidation()
        {
            RuleFor(co => co.Checkout)
                .NotEmpty().WithMessage("Checkout is required")
                .NotNull().WithMessage("Checkout cannot be null");
        }
    }
}
