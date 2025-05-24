using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotifocationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet("GetAllNotification")]
        public IActionResult GetAllNotification()
        {
            var notifications = _notificationService.TGetListAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(notifications));
        }

        [HttpGet("GetNotificationById/{id}")]
        public IActionResult GetNotificationById(int id)
        {
            var notification = _notificationService.TGetById(id);
            return Ok(_mapper.Map<GetNotificationDto>(notification));
        }

        [HttpPost("AddNotification")]
        public IActionResult AddNotification(CreateNotificationDto createNotificationDto)
        {
            var value = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(value);
            return Ok("Notification was added");
        }

        [HttpPut("UpdateNotification")]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(value);
            return Ok("Notification was updated");
        }

        [HttpDelete("DeleteNotification/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Notification was deleted");
        }

        [HttpGet("GetActiveNotification")]
        public IActionResult GetActiveNotification()
        {
            var result = _notificationService.TGetActiveNotification();
            return Ok(result);
        }

        [HttpPut("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _notificationService.TChangeStatusToTrue(id);
            return Ok("Notification status was changed to true");
        }
    }
}
