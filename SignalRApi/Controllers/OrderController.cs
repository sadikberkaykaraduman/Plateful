using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("GetAllOrder")]
        public IActionResult GetAllOrder()
        {
            var orders = _orderService.TGetListAll();
            return Ok(_mapper.Map<List<ResultOrderDto>>(orders));
        }

        [HttpGet("GetOrderById/{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.TGetById(id);
            return Ok(order);
        }

        [HttpPost("AddOrder")]
        public IActionResult AddOrder(CreateOrderDto createOrderDetailDto)
        {
            var value = _mapper.Map<Order>(createOrderDetailDto);
            _orderService.TAdd(value);
            return Ok("Order was added");
        }

        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder(UpdateOrderDto updateOrderDetailDto)
        {
            var value = _mapper.Map<Order>(updateOrderDetailDto);
            _orderService.TUpdate(value);
            return Ok("Order was updated");
        }

        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var value = _orderService.TGetById(id);
            _orderService.TDelete(value);
            return Ok("Order was deleted");
        }

        [HttpGet("GetOrderCount")]
        public IActionResult GetOrderCount()
        {
            var orderCount = _orderService.TOrderCount();
            return Ok(orderCount);
        }

        [HttpGet("GetActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            var activeOrderCount = _orderService.TActiveOrderCount();
            return Ok(activeOrderCount);
        }

        [HttpGet("GetPassiveOrderCount")]
        public IActionResult GetPassiveOrderCount()
        {
            var passiveOrderCount = _orderService.TPassiveOrderCount();
            return Ok(passiveOrderCount);
        }

        [HttpGet("GetLastOrderAmount")]
        public IActionResult GetLastOrderAmount()
        {
            var lastOrderAmount = _orderService.TLastOrderAmount();
            return Ok(lastOrderAmount);
        }

        [HttpGet("GetTodayIncome")]
        public IActionResult GetTodayIncome()
        {
            var todayIncome = _orderService.TTodayIncome();
            return Ok(todayIncome);
        }
    }
}
