using AutoMapper;
using SignalR.DtoLayer.ContactDtos;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.GeneralMapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
        }
    }
}
