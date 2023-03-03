using ECommerce.Application.Commands;
using FluentValidation;

namespace ECommerce.Application.Validation
{
        public class AddCartItemCommandValidation : AbstractValidator<AddCartItemCommand>
        {
            public AddCartItemCommandValidation()
            {
                RuleFor(ci => ci.ShopperId)
                    .NotEmpty().WithMessage("Shopper Id is required")
                    .NotNull().WithMessage("Shopper Id cannot be null");

                RuleFor(ci => ci.ProductName)
                    .NotEmpty().WithMessage("Product is required")
                    .NotNull().WithMessage("Product cannot be null");
            }
        }
    }
