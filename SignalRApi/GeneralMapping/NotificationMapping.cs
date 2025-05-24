using AutoMapper;
using SignalR.DtoLayer.NotifocationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.GeneralMapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationDto>().ReverseMap();
        }
    }
}
