using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CashRegisterDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashRegisterController : ControllerBase
    {
        private readonly ICashRegisterService _cashRegisterService;
        private readonly IMapper _mapper;

        public CashRegisterController(ICashRegisterService cashRegisterService, IMapper mapper)
        {
            _cashRegisterService = cashRegisterService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCashRegisters")]
        public IActionResult GetAllCashRegisters()
        {
            var cashRegisters = _cashRegisterService.TGetListAll();
            return Ok(_mapper.Map<List<ResultCashRegisterDto>>(cashRegisters));
        }

        [HttpGet("GetCashRegisterById/{id}")]
        public IActionResult GetCashRegisterById(int id)
        {
            var cashRegister = _cashRegisterService.TGetById(id);
            return Ok(_mapper.Map<GetCashRegisterDto>(cashRegister));
        }

        [HttpPost("AddCashRegister")]
        public IActionResult AddCashRegister(CreateCashRegisterDto createCashRegisterDto)
        {
            var cashRegister = _mapper.Map<CashRegister>(createCashRegisterDto);
            _cashRegisterService.TAdd(cashRegister);
            return Ok("Cash Register was added");
        }

        [HttpPut("UpdateCashRegister")]
        public IActionResult UpdateCashRegister(UpdateCashRegisterDto updateCashRegisterDto)
        {
            var cashRegister = _mapper.Map<CashRegister>(updateCashRegisterDto);
            _cashRegisterService.TUpdate(cashRegister);
            return Ok("Cash Register was updated");
        }

        [HttpDelete("DeleteCashRegister/{id}")]
        public IActionResult DeleteCashRegister(int id)
        {
            var cashRegister = _cashRegisterService.TGetById(id);
            if (cashRegister == null)
            {
                return NotFound("Cash Register not found");
            }
            _cashRegisterService.TDelete(cashRegister);
            return Ok("Cash Register was deleted");
        }

        [HttpGet("GetTotalCashRegisterAmount")]
        public IActionResult GetTotalCashRegisterAmount()
        {
            var totalAmount = _cashRegisterService.TGetTotalCashRegisterAmount();
            return Ok(totalAmount);
        }
    }
}
