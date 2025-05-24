using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet("GetAllMenuTable")]
        public IActionResult GetAllMenuTable()
        {
            var menuTables = _menuTableService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(menuTables));
        }

        [HttpGet("GetMenuTableById/{id}")]
        public IActionResult GetMenuTableById(int id)
        {
            var menuTable = _menuTableService.TGetById(id);
            return Ok(_mapper.Map<GetMenuTableDto>(menuTable));
        }

        [HttpPost("AddMenuTable")]
        public IActionResult AddMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            var value = _mapper.Map<MenuTable>(createMenuTableDto);
            _menuTableService.TAdd(value);
            return Ok("Menu Table was added");
        }

        [HttpPut("UpdateMenuTable")]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var value = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(value);
            return Ok("Menu Table was updated");
        }

        [HttpDelete("DeleteMenuTable/{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var menuTable = _menuTableService.TGetById(id);
            if (menuTable == null)
            {
                return NotFound();
            }
            _menuTableService.TDelete(menuTable);
            return Ok("Menu Table was deleted");
        }

        [HttpGet("GetMenuTableCount")]
        public IActionResult GetMenuTableCount()
        {
            var menuTable = _menuTableService.TGetMenuTableCount();
            return Ok(menuTable);
        }

        [HttpPut("ChangeMenuTableStatusToTrue/{id}")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
            var menuTable = _menuTableService.TGetById(id);
            _menuTableService.TChangeMenuTableStatusToTrue(id);
            return Ok("Menu Table status was changed to true");
        }

        [HttpPut("ChangeMenuTableStatusToFalse/{id}")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            var menuTable = _menuTableService.TGetById(id);
            _menuTableService.TChangeMenuTableStatusToFalse(id);
            return Ok("Menu Table status was changed to false");
        }
    }
}
