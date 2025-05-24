using AutoMapper;
using SignalR.DtoLayer.CashRegisterDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.GeneralMapping
{
    public class CashRegisterMapping : Profile
    {
        public CashRegisterMapping()
        {

            CreateMap<CashRegister, ResultCashRegisterDto>().ReverseMap();
            CreateMap<CashRegister, CreateCashRegisterDto>().ReverseMap();
            CreateMap<CashRegister, UpdateCashRegisterDto>().ReverseMap();
            CreateMap<CashRegister, GetCashRegisterDto>().ReverseMap();
        }
    }
}
