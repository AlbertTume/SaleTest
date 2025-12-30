using Microsoft.AspNetCore.Mvc;
using SaliTest.Application.DTOs;
using SaliTest.Application.Interfaces;
using SaliTest.Domain.Entities;

namespace SaliTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductServices productServices, ILogger<ProductController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            try
            {
                var products = await _productServices.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all products.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDto>> GetProductById(long productId)
        {
            try
            {
                if (productId <= 0)
                {
                    return BadRequest("Invalid product ID.");
                }

                var product = await _productServices.GetProductByIdAsync(productId);
                
                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the product with ID {productId}.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}