using ArriveApi.Entities;
using ArriveApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArriveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepository.GetList();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(Guid productId)
        {
            Product? productResult = await _productRepository.GetById(productId);

            if (productResult == null)
            {
                return NotFound();
            }

            return Ok(productResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            //do some validation in a logic/business layer class. If product is unique and a warehouse is required continue otherwise return BadRequest
            Product? newProduct = await _productRepository.Create(product);

            if (newProduct == null)
            {
                return StatusCode(500);
            }

            return Ok(newProduct);

        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Put(Guid productId, [FromBody] int quantity)
        {
            Product? productUpdateResult = await _productRepository.UpdateQuantity(productId, quantity);

            if (productUpdateResult == null)
            {
                return NotFound();
            }

            return Ok(productUpdateResult);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            bool isDeleted = await _productRepository.Delete(productId);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
