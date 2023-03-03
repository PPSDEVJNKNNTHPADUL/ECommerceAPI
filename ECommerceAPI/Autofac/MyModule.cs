using Autofac;
using ECommerce.Application.Commands;
using ECommerce.Application.Handlers;
using ECommerce.Application.Validation;
using ECommerce.Domain.Interface;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Repository;
using FluentValidation;
using MediatR;

namespace ECommerceAPI.Autofac
{
    public class MyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ValidationBehavior<,>))
                .As(typeof(IPipelineBehavior<,>))
                .InstancePerDependency();

            builder.RegisterType<UserValidator.UserValidation>()
                .As<IValidator<UserCommand.AddUserCommand>>()
                .InstancePerDependency();

            builder.RegisterType<CartItemValidator.AddCartItemCommandValidation>()
                .As<IValidator<CartItemCommand.AddCartItemCommand>>()
                .InstancePerDependency();

            builder.RegisterType<CartItemValidator.UpdateCartItemCommandValidation>()
                .As<IValidator<CartItemCommand.UpdateCartItemCommand>>()
                .InstancePerDependency();

            builder.RegisterType<CartItemValidator.DeleteCartItemCommandValidation>()
                .As<IValidator<CartItemCommand.DeleteCartItemCommand>>()
                .InstancePerDependency();

            builder.RegisterType<OrderValidator.UpdateOrderCommandValidation>()
                .As<IValidator<OrderCommand.UpdateOrderCommand>>()
                .InstancePerDependency();

            builder.RegisterType<OrderValidator.DeleteOrderCommandValidation>()
                .As<IValidator<OrderCommand.DeleteOrderCommand>>()
                .InstancePerDependency();

            builder.RegisterType<CheckoutValidation>()
                .As<IValidator<CheckoutCommand.CheckoutOrderCommand>>()
                .InstancePerDependency();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerDependency();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerDependency();

            builder.RegisterType<CartItemRepository>()
                .As<ICartItemRepository>()
                .InstancePerDependency();

            builder.RegisterType<CheckoutRepository>()
                .As<ICheckoutRepository>()
                .InstancePerDependency();

            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(UserHandler.AddUserCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CartItemHandler.AddCartItemCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CheckoutHandler.CheckoutOrderCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CartItemHandler.DeleteCartItemCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(OrderHandler.DeleteOrderCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CartItemHandler.GetAllCartItemQueryHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(OrderHandler.GetOrderByIdQueryHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(OrderHandler.GetOrdersQueryHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UserHandler.GetUserByIdQueryHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CartItemHandler.UpdateCartItemCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(OrderHandler.UpdateOrderCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));



        }
    }
}
