using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet("GetAllTestimonials")]
        public IActionResult GetAllTestimonials()
        {
            var testimonials = _testimonialService.TGetListAll();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(testimonials));
        }

        [HttpGet("GetTestimonialById/{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            return Ok(_mapper.Map<GetTestimonialDto>(testimonial));
        }

        [HttpPost("AddTestimonial")]
        public IActionResult AddTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);
            return Ok("Testimonial was added");
        }

        [HttpPut("UpdateTestimonial")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Testimonial was updated");
        }

        [HttpDelete("DeleteTestimonial/{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            _testimonialService.TDelete(testimonial);
            return Ok("Testimonial was deleted");
        }
    }
}
