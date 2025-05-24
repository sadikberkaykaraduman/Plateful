using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet("GetAllMessages")]
        public IActionResult GetAllMessages()
        {
            var messages = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(messages));
        }

        [HttpGet("GetMessageById/{id}")]
        public IActionResult GetMessageById(int id)
        {
            var message = _messageService.TGetById(id);
            return Ok(_mapper.Map<GetMessageDto>(message));
        }

        [HttpPost("AddMessage")]
        public IActionResult AddMessage(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            value.SendDate = DateTime.Now;
            _messageService.TAdd(value);
            return Ok("Message was added");
        }

        [HttpPut("UpdateMessage")]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Message was updated");
        }

        [HttpDelete("DeleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var message = _messageService.TGetById(id);
            _messageService.TDelete(message);
            return Ok("Message was deleted");
        }
    }
}
