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
            CreateMap<AddUserDTO, AddUserCommand>().ReverseMap();
            CreateMap<AddUserCommand, UserModel>().ReverseMap();

            //CartItem
            CreateMap<CartItemModel, CartItemEntity>().ReverseMap();
            CreateMap<AddCartItemDTO, CartItemEntity>().ReverseMap();
            CreateMap<CartItemModel, CartItemDTO>().ReverseMap();
            CreateMap<UpdateCartItemCommand, CartItemModel>().ReverseMap();
            CreateMap<UpdateCartItemDTO, CartItemEntity>().ReverseMap();


            //Orders
            CreateMap<CheckoutModel, OrderEntity>().ReverseMap();

            //Checkout
            CreateMap<CheckoutModel, CheckoutEntity>().ReverseMap();
        }
    }
}
