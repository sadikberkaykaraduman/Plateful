using AutoMapper;
using SignalR.DtoLayer.MenuTableDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.GeneralMapping
{
    public class MenuTableMapper : Profile
    {
        public MenuTableMapper()
        {
            CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
        }
    }
}
