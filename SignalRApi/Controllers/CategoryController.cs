using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.TGetListAll();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(categories));
        }

        [HttpGet("GetCategoryById/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.TGetById(id);
            return Ok(_mapper.Map<GetCategoryDto>(category));
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);
            return Ok("Category was added");
        }

        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("Category was updated");
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            _categoryService.TDelete(category);
            return Ok("Category was deleted");
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var count = _categoryService.TCategoryCount();
            return Ok(count);
        }

        [HttpGet("GetActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount()
        {
            var count = _categoryService.TActiveCategoryCount();
            return Ok(count);
        }

        [HttpGet("GetPassiveCategoryCount")]
        public IActionResult GetPassiveCategoryCount()
        {
            var count = _categoryService.TPasssiveCategoryCount();
            return Ok(count);
        }
    }
}
