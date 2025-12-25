using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Services;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        //  Get all products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            try
            {
                var products = await _service.GetAllAsync();
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //  Get product by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                var product = await _service.GetByIdAsync(id);
                if (product == null)
                    return NotFound("Product not found");

                return Ok(product);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //  Get products by Category
        [HttpGet("category/{categoryName}")]
        public async Task<ActionResult<List<Product>>> GetByCategory(string categoryName)
        {
            try
            {
                var products = await _service.FilterByCategoryAsync(categoryName);
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //  Search by Name or Description
        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<List<Product>>> SearchProducts(string searchTerm)
        {
            try
            {
                var products = await _service.SearchAsync(searchTerm);
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //  Filter by Price Range
        [HttpGet("price")]
        public async Task<ActionResult<List<Product>>> FilterByPrice([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            try
            {
                var products = await _service.FilterByPriceRangeAsync(minPrice, maxPrice);
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
