using AutoMapper;
using ECommerce.Application.Commands;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Models;

namespace ECommerceAPI.Mapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            //Source ----> Destination

            //User
            CreateMap<UserModel, UserEntity>().ReverseMap();
            CreateMap<AddUserDTO, UserCommand.AddUserCommand>().ReverseMap();
            CreateMap<UserCommand.AddUserCommand, UserModel>().ReverseMap();
            CreateMap<UserCommand.AddUserCommand, UserEntity>().ReverseMap();

            //CartItem
            CreateMap<CartItemModel, CartItemEntity>().ReverseMap();
            CreateMap<AddCartItemDTO, CartItemEntity>().ReverseMap();
            CreateMap<CartItemModel, CartItemDTO>().ReverseMap();
            CreateMap<CartItemCommand.UpdateCartItemCommand, CartItemEntity>().ReverseMap();
            CreateMap<UpdateCartItemDTO, CartItemEntity>().ReverseMap();


            //Orders
            CreateMap<CheckoutModel, OrderEntity>().ReverseMap();

            //Checkout
            CreateMap<CheckoutModel, CheckoutEntity>().ReverseMap();
        }
    }
}
