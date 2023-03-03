using FluentValidation;

namespace ECommerce.Application.Validation
{
    public class CartItemValidation
    {
        public class AddCartItemCommandValidator : AbstractValidator<AddCartItemCommandValidator>
        {
        }
    }
}
