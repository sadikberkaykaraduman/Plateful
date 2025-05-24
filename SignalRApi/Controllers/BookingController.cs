using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingServices;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingController(IBookingService bookingServices, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingServices = bookingServices;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("GetAllBookings")]
        public IActionResult GetAllBookings()
        {
            var bookings = _bookingServices.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(bookings));
        }

        [HttpGet("GetBookingById/{id}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = _bookingServices.TGetById(id);
            return Ok(_mapper.Map<GetBookingDto>(booking));
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingServices.TAdd(value);
            return Ok("Booking was added");
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingServices.TUpdate(value);
            return Ok("Booking was updated");
        }

        [HttpDelete("DeleteBooking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _bookingServices.TGetById(id);
            _bookingServices.TDelete(booking);
            return Ok("Booking was deleted");
        }
    }
}
