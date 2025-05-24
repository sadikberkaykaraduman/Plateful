using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.TGetListAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(products));
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.TGetById(id);
            return Ok(_mapper.Map<GetProductDto>(product));
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
            return Ok("Product was added");
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Product was updated");
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetById(id);
            _productService.TDelete(product);
            return Ok("Product was deleted");
        }

        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory()
        {
            var context = new RestorantDbContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                ProductDescription = y.ProductDescription,
                ProductImageUrl = y.ProductImageUrl,
                ProductPrice = y.ProductPrice,
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                ProductCategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }

        [HttpGet("GetProductWithCategoryById/{id}")]
        public IActionResult GetProductWithCategoryById(int id)
        {
            var context = new RestorantDbContext();
            var values = context.Products.Include(x => x.Category).Where(x => x.ProductId == id).Select(y => new ResultProductWithCategory
            {
                ProductDescription = y.ProductDescription,
                ProductImageUrl = y.ProductImageUrl,
                ProductPrice = y.ProductPrice,
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                ProductCategoryName = y.Category.CategoryName
            }).FirstOrDefault();
            return Ok(values);
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var productCount = _productService.TProductCount();
            return Ok(productCount);
        }

        [HttpGet("GetProductCountByHamburgerCategory")]
        public IActionResult GetProductCountByHamburgerCategory()
        {
            var productCount = _productService.TProductCountByHamburgerCategory();
            return Ok(productCount);
        }

        [HttpGet("GetProductCountByWrapsCategory")]
        public IActionResult GetProductCountByWrapsCategory()
        {
            var productCount = _productService.TProductCountByWrapsCategory();
            return Ok(productCount);
        }

        [HttpGet("GetCheapestProduct")]
        public IActionResult GetCheapestProduct()
        {
            var product = _productService.TGetCheapest();
            return Ok(product);
        }

        [HttpGet("GetExpensiveProduct")]
        public IActionResult GetExpensiveProduct()
        {
            var product = _productService.TGetExpesive();
            return Ok(product);
        }

        [HttpGet("GetAverageProductPrice")]
        public IActionResult GetAverageProductPrice()
        {
            var averagePrice = _productService.TAverageProductPrice();
            return Ok(averagePrice);
        }

        [HttpGet("GetAverageHamburgerPrice")]
        public IActionResult GetAverageHamburgerPrice()
        {
            var averagePrice = _productService.TAverageHamburgerPrice();
            return Ok(averagePrice);
        }

        [HttpGet("GetProductPriceByBaconBurger")]
        public IActionResult GetProductPriceByBaconBurger()
        {
            var productPrice = _productService.TProductPriceByBaconBurger();
            return Ok(productPrice);
        }

        [HttpGet("GetTotalPriceByDessertsCategory")]
        public IActionResult GetTotalPriceByDessertsCategory()
        {
            var totalPrice = _productService.TTotalPriceByDessertsCategory();
            return Ok(totalPrice);
        }

        [HttpGet("GetTotalPriceBySaladCategory")]
        public IActionResult GetTotalPriceBySaladCategory()
        {
            var totalPrice = _productService.TTotalPriceBySaladCategory();
            return Ok(totalPrice);
        }

        [HttpGet("GetProductCountByBeveragesCategory")]
        public IActionResult GetProductCountByBeveragesCategory()
        {
            var productCount = _productService.TProductCountByBeveragesCategory();
            return Ok(productCount);
        }

        [HttpGet("GetProductPriceSummary")]
        public IActionResult GetProductPriceSummary()
        {
            var productPriceSummary = _productService.TProductPriceSummary();
            return Ok(productPriceSummary);
        }

        [HttpGet("GetFirst9Products")]
        public IActionResult GetFirst9Products()
        {
            var products = _productService.TGetFirst9Products();
            return Ok(products);
        }
    }
}
