using Autofac;
using ECommerce.Application.Commands;
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

            builder.RegisterType<UserValidation>()
                .As<IValidator<AddUserCommand>>()
                .InstancePerDependency();




            builder.RegisterType<UserValidation>()
                .As<IValidator<AddUserCommand>>()
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
        }
    }
}
