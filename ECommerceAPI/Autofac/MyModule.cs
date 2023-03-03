using Autofac;
using ECommerce.Application.Commands;
using ECommerce.Application.Handlers;
using ECommerce.Application.Validation;
using ECommerce.Domain.Interface;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Repository;
using ECommerceAPI.Mapper;
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

            builder.RegisterType<UserValidation>()
                .As<IValidator<AddUserCommand>>()
                .InstancePerDependency();

            builder.RegisterType<AddCartItemCommandValidation>()
                .As<IValidator<AddCartItemCommand>>()
                .InstancePerDependency();

            builder.RegisterType<UpdateCartItemCommandValidation>()
                .As<IValidator<UpdateCartItemCommand>>()
                .InstancePerDependency();

            builder.RegisterType<DeleteCartItemCommandValidation>()
                .As<IValidator<DeleteCartItemCommand>>()
                .InstancePerDependency();

            builder.RegisterType<UpdateOrderCommandValidation>()
                .As<IValidator<UpdateOrderCommand>>()
                .InstancePerDependency();

            builder.RegisterType<DeleteOrderCommandValidation>()
                .As<IValidator<DeleteOrderCommand>>()
                .InstancePerDependency();

            builder.RegisterType<CheckoutValidation>()
                .As<IValidator<CheckoutOrderCommand>>()
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

            builder.RegisterAssemblyTypes(typeof(AddUserCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(AddCartItemCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(CheckoutOrderCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteCartItemCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteOrderCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetAllCartItemQueryHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetOrderByIdQueryHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetOrdersQueryHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetUserByIdQueryHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(UpdateCartItemCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(UpdateOrderCommandHandler).Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));



        }
    }
}
