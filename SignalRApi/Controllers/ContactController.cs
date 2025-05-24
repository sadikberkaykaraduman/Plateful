using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("GetAllContacts")]
        public IActionResult GetAllContacts()
        {
            var contacts = _contactService.TGetListAll();
            return Ok(_mapper.Map<List<ResultContactDto>>(contacts));
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.TGetById(id);
            return Ok(_mapper.Map<GetContactDto>(contact));
        }

        [HttpPost("AddContact")]
        public IActionResult AddContact(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);
            return Ok("Contact was added");
        }

        [HttpPut("UpdateContact")]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("Contact was updated");
        }

        [HttpDelete("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.TGetById(id);
            _contactService.TDelete(contact);
            return Ok("Contact was deleted");
        }
    }
}
