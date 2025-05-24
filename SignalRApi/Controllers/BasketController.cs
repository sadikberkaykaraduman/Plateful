using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("GetAllBasket")]
        public IActionResult GetAllBasket()
        {
            var baskets = _basketService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBasketDto>>(baskets));
        }

        [HttpGet("GetBasketById/{id}")]
        public IActionResult GetBasketById(int id)
        {
            var basket = _basketService.TGetById(id);
            return Ok(_mapper.Map<GetBasketDto>(basket));
        }

        [HttpPost("AddBasket")]
        public IActionResult AddBasket(CreateBasketDto createBasketDto)
        {
            var value = _mapper.Map<Basket>(createBasketDto);
            _basketService.TAdd(value);
            return Ok("Basket was added");
        }

        [HttpPut("UpdateBasket")]
        public IActionResult UpdateBasket(UpdateBasketDto updateBasketDto)
        {
            var value = _mapper.Map<Basket>(updateBasketDto);
            _basketService.TUpdate(value);
            return Ok("Basket was updated");
        }

        [HttpDelete("DeleteBasket/{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Basket was deleted");
        }

        [HttpGet("GetListWithProductByMenuTableId/{id}")]
        public IActionResult GetListWithProductByMenuTableId(int id)
        {
            var context = new RestorantDbContext();
            var value = context.Baskets.Include(x => x.Product).Where(x => x.BasketMenuTableId == id).Select(y => new ResultBasketWithProduct
            {
                BasketId = y.BasketId,
                BasketProductId = y.BasketProductId,
                BasketProductCount = y.BasketProductCount,
                BasketProductUnitPrice = y.BasketProductUnitPrice,
                BasketTotalPrice = y.BasketTotalPrice,
                BasketMenuTableId = y.BasketMenuTableId,
                BasketProductName = y.Product.ProductName
            }).ToList();
            return Ok(value);
        }
    }
}
