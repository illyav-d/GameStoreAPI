using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Data.Entities;
using GameStoreAPI.DTO.GameProduct;
using GameStoreAPI.DTO.Genre;
using GameStoreAPI.DTO.Order;
using GameStoreAPI.DTO.Platform;
using GameStoreAPI.DTO.ShoppingCart;
using GameStoreAPI.DTO.User;

namespace GameStoreAPI.Config
{
    public class GameStoreProfile : Profile
    {
       public GameStoreProfile() 
        { 
            //GET (ALL) Mapping (GameProduct en toebehoren)
            CreateMap<GameProductEntity, GameProduct>().ReverseMap();
            CreateMap<GameProduct, GameProductDTO>()
                .ForMember(x => x.GenreName, y => y.MapFrom(z => z.Genre.Name))
                .ForMember(x => x.PlatformName, y => y.MapFrom(z => z.Platform.Name));

            CreateMap<GenreEntity, Genre>().ReverseMap();
            CreateMap<Genre, GenreDTO>();

            CreateMap<PlatformEntity, Platform>().ReverseMap();
            CreateMap<Platform, PlatformDTO>();

            CreateMap<GameProduct, SimplifiedGameProductDTO>();

            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<User, DetailedUserDTO>();
            CreateMap<User, SimplifiedUserDTO>();

            CreateMap<ShoppingCartProductEntity, ShoppingCartProduct>().ReverseMap();
            CreateMap<ShoppingCartProduct, ShoppingCartProductWithUserDTO>()
            .ForMember(x => x.GameProductName, y => y.MapFrom(z => z.GameProduct.Name))
            .ForMember(x => x.GameProductPrice, y => y.MapFrom(z => z.GameProduct.PriceInEuro))
            .ForMember(x => x.UserID, y => y.MapFrom(z => z.User.ID))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.User.Name));

            CreateMap<ShoppingCartProduct, SimplifiedShoppingCartProductDTO>()
           .ForMember(x => x.GameProductName, y => y.MapFrom(z => z.GameProduct.Name))
           .ForMember(x => x.GameProductPrice, y => y.MapFrom(z => z.GameProduct.PriceInEuro));

            CreateMap<OrderEntity, Order>().ReverseMap();
            CreateMap<Order, OrderDTO>();

            //DTOs input omzetten naar model

            //Update
            CreateMap<UpdateGameProductDTO, GameProduct>();
            CreateMap<UpdateGameProductActiveStateDTO, GameProduct>();
            CreateMap<UpdateGameProductPriceDTO, GameProduct>();
            CreateMap<UpdateGameProductStockDTO, GameProduct>();

            CreateMap<UpdateGenreDTO, Genre>();

            CreateMap<UpdateUserNameDTO, User>();
            CreateMap<UpdateUserActiveStateDTO, User>();

            CreateMap<UpdatePlatformDTO, Platform>();

            CreateMap<UpdateShoppingCartProductAmountDTO, ShoppingCartProduct>();

            //Add
            CreateMap<AddUserDTO, User>();

            CreateMap<AddGameProductDTO,  GameProduct>();

            CreateMap<AddGenreDTO, Genre>();

            CreateMap<AddPlatformDTO, Platform>();

            CreateMap<AddShoppingCartProductDTO, ShoppingCartProduct>();

            CreateMap<AddOrderDTO, Order>();
        }
    }
}
