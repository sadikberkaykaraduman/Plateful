using AutoMapper;
using SignalR.DtoLayer.OrderDetailDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.GeneralMapping
{
    public class OrderDetailMapping : Profile
    {
        public OrderDetailMapping()
        {
            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, ResultOrderDetailWithProductDto>().ReverseMap();
            CreateMap<OrderDetail, ResultOrderDetailWithProductByOrderIdDto>().ReverseMap();
        }
    }
}
