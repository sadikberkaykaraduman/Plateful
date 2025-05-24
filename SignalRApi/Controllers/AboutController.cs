using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet("GetAllAbout")]
        public IActionResult GetAllAbout()
        {
            var abouts = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(abouts));
        }

        [HttpGet("GetAboutById/{id}")]
        public IActionResult GetAboutById(int id)
        {
            var about = _aboutService.TGetById(id);
            return Ok(_mapper.Map<GetAboutDto>(about));
        }

        [HttpPost("AddAbout")]
        public IActionResult AddAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(value);
            return Ok("About was added");
        }

        [HttpPut("UpdateAbout")]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok("About was updated");
        }

        [HttpDelete("DeleteAbout/{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("About was deleted");
        }
    }
}
