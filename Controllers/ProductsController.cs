using ArriveApi.Entities;
using ArriveApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            List<Product> products = await _productRepository.GetList();

            //do some mapping here, probably in a logic/manager class. Ideally we don't want to expose our entities

            return Ok(products);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid productId)
        {
            Product? productResult = await _productRepository.GetById(productId);

            if (productResult == null)
            {
                return NotFound();
            }

            //do some mapping here, probably in a logic/manager class. Ideally we don't want to expose our entities

            return Ok(productResult);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            //do some validation in a logic/business layer class. If product is unique and a warehouse is required continue otherwise return BadRequest
            Product? newProduct = await _productRepository.Create(product);

            if (newProduct == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            //do some mapping here, probably in a logic/manager class. Ideally we don't want to expose our entities

            return Ok(newProduct);

        }

        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid productId, [FromBody] int quantity)
        {
            //do we allow negative quantities? If not we should return the error saying so
            Product? productUpdateResult = await _productRepository.UpdateQuantity(productId, quantity);

            if (productUpdateResult == null)
            {
                return NotFound();
            }

            //do some mapping here, probably in a logic/manager class. Ideally we don't want to expose our entities

            return Ok(productUpdateResult);
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
