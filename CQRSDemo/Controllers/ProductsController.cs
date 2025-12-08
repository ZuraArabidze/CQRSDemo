using CQRSDemo.CQRS.Commands;
using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.CQRS.Queries;
using CQRSDemo.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ProductsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest request)
        {
            var command = new CreateProductCommand(request.Name, request.Price, request.Stock);
            var productId = await _commandDispatcher.Dispatch<CreateProductCommand, int>(command);

            return Ok(productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            var command = new UpdateProductCommand(id, request.Name, request.Price, request.Stock);
            var result = await _commandDispatcher.Dispatch<UpdateProductCommand, bool>(command);
            
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _commandDispatcher.Dispatch<DeleteProductCommand, bool>(command);
            return result ? NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _queryDispatcher.Dispatch<GetProductByIdQuery, ProductDto>(query);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _queryDispatcher.Dispatch<GetAllProductsQuery, List<ProductDto>>(query);
            return Ok(products);
        }
    }
}
