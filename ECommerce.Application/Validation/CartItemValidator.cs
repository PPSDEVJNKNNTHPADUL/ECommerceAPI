using ECommerce.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validation
{
    public class CartItemValidator
    {
        public class AddCartItemCommandValidation : AbstractValidator<CartItemCommand.AddCartItemCommand>
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
        public class DeleteCartItemCommandValidation : AbstractValidator<CartItemCommand.DeleteCartItemCommand>
        {
            public DeleteCartItemCommandValidation()
            {
                RuleFor(ci => ci.CartItemId)
                    .NotEmpty().WithMessage("CartItemId is required")
                    .NotNull().WithMessage("CartItemId cannot be null");
            }
        }
        public class UpdateCartItemCommandValidation : AbstractValidator<CartItemCommand.UpdateCartItemCommand>
        {
            public UpdateCartItemCommandValidation()
            {
 /*               RuleFor(ci => ci.CartItemId)
                    .NotEmpty().WithMessage("Shopper Id is required")
                    .NotNull().WithMessage("Shopper Id cannot be null");*/

                RuleFor(ci => ci.ProductName)
                    .NotEmpty().WithMessage("Shopper Id is required")
                    .NotNull().WithMessage("Shopper Id cannot be null");
            }
        }
    }
}
