using AutoMapper;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.GeneralMapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping() 
        {
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, UpdateBasketDto>().ReverseMap();
            CreateMap<Basket, GetBasketDto>().ReverseMap();
        }
    }
}
