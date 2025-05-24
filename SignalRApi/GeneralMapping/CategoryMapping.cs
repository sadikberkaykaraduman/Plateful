using AutoMapper;
using SignalR.DtoLayer.BookingDtos;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.GeneralMapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
        }
    }
}
