using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet("GetAllDiscounts")]
        public IActionResult GetAllDiscounts()
        {
            var discounts = _discountService.TGetListAll();
            return Ok(_mapper.Map<List<ResultDiscountDto>>(discounts));
        }

        [HttpGet("GetDiscountById/{id}")]
        public IActionResult GetDiscountById(int id)
        {
            var discount = _discountService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDto>(discount));
        }

        [HttpPost("AddDiscount")]
        public IActionResult AddDiscount(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);
            return Ok("Discount was added");
        }

        [HttpPut("UpdateDiscount")]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("Discount was updated");
        }

        [HttpDelete("DeleteDiscount/{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var discount = _discountService.TGetById(id);
            _discountService.TDelete(discount);
            return Ok("Discount was deleted");
        }

        [HttpGet("GetActiveDiscount")]
        public IActionResult GetActiveDiscount()
        {
            var discounts = _discountService.TGetActiveDiscount();
            return Ok(discounts);
        }

        [HttpPut("SetDiscountPassive/{id}")]
        public IActionResult SetDiscountPassive(int id)
        {
            _discountService.TSetDicontPassive(id);
            return Ok("Discount was set to passive");
        }

        [HttpPut("SetDiscountActive/{id}")]
        public IActionResult SetDiscountActive(int id)
        {
            _discountService.TSetDicontActive(id);
            return Ok("Discount was set to active");
        }
    }
}
