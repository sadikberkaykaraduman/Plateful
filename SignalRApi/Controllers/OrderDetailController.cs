using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.OrderDetailDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        [HttpGet("GetAllOrderDetail")]
        public IActionResult GetAllOrderDetail()
        {
            var orders = _orderDetailService.TGetListAll();
            return Ok(_mapper.Map<List<ResultOrderDetailDto>>(orders));
        }

        [HttpGet("GetOrderDetailById/{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            var order = _orderDetailService.TGetById(id);
            return Ok(_mapper.Map<GetOrderDetailDto>(order));
        }

        [HttpPost("AddOrderDetail")]
        public IActionResult AddOrderDetail(CreateOrderDetailDto createOrderDetailDto)
        {
            var value = _mapper.Map<OrderDetail>(createOrderDetailDto);
            _orderDetailService.TAdd(value);
            return Ok("Order was added");
        }

        [HttpPut("UpdateOrderDetail")]
        public IActionResult UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto)
        {
            var value = _mapper.Map<OrderDetail>(updateOrderDetailDto);
            _orderDetailService.TUpdate(value);
            return Ok("Order was updated");
        }

        [HttpDelete("DeleteOrderDetail/{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var value = _orderDetailService.TGetById(id);
            _orderDetailService.TDelete(value);
            return Ok("Order was deleted");
        }

        [HttpGet("GetOrderWithProduct")]
        public IActionResult GetOrderWithProduct()
        {
            var context = new RestorantDbContext();
            var values = context.OrderDetails.Include(x => x.Product).Select(y => new ResultOrderDetailWithProductDto
            {
                OrderDetailId = y.OrderDetailId,
                OrderDetailProductName = y.Product.ProductName,
                OrderDetailPiece = y.OrderDetailPiece,
                OrderDetailUnitPrice = y.OrderDetailUnitPrice,
                OrderDetailTotalPrice = y.OrderDetailTotalPrice,
                OrderDetailOrderId = y.OrderDetailOrderId,
            });
            return Ok(values.ToList());
        }

        [HttpGet("GetOrderWithProductByOrderId/{id}")]
        public IActionResult GetOrderWithProductByOrderid(int id)
        {
            var context = new RestorantDbContext();
            var value = context.OrderDetails.Include(x => x.Product).Where(x => x.OrderDetailId == id).Select(y => new ResultOrderDetailWithProductByOrderIdDto
            {
                OrderDetailId = y.OrderDetailId,
                OrderDetailProductName = y.Product.ProductName,
                OrderDetailPiece = y.OrderDetailPiece,
                OrderDetailUnitPrice = y.OrderDetailUnitPrice,
                OrderDetailTotalPrice = y.OrderDetailTotalPrice,
                OrderDetailOrderId = y.OrderDetailOrderId,
            }).FirstOrDefault(); 
            return Ok(value);
        }
    }
}
