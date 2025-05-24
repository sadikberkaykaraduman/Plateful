using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet("GetAllSocialMedia")]
        public IActionResult GetAllSocialMedia()
        {
            var socialMedias = _socialMediaService.TGetListAll();
            return Ok(_mapper.Map<List<ResultSocialMediaDto>>(socialMedias));
        }

        [HttpGet("GetSocialMediaById/{id}")]
        public IActionResult GetSocialMediaById(int id)
        {
            var socialMedia = _socialMediaService.TGetById(id);
            return Ok(_mapper.Map<GetSocialMediaDto>(socialMedia));
        }

        [HttpPost("AddSocialMedia")]
        public IActionResult AddSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(value);
            return Ok("Social Media was added");
        }

        [HttpPut("UpdateSocialMedia")]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(value);
            return Ok("Social Media was updated");
        }

        [HttpDelete("DeleteSocialMedia/{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var socialMedia = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(socialMedia);
            return Ok("Social Media was deleted");
        }
    }
}
