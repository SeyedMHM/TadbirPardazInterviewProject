using MediatR;
using Microsoft.AspNetCore.Mvc;
using TadbirPardazProject.Application.Products.Commands.Create;
using TadbirPardazProject.Application.Products.Commands.Delete;
using TadbirPardazProject.Application.Products.Commands.Update;
using TadbirPardazProject.Application.Products.Queries.GetAll;
using TadbirPardazProject.Application.Products.Queries.GetById;
using TadbirPardazProject.Application.Products.Queries.GetPagedList;
using TadbirPardazProject.Shared.Api.Filters;

namespace TadbirPardazProject.Endpoint.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ApiResultFilter]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductGetByIdQuery input, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(input, cancellationToken);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(request, cancellationToken);

            return Ok(products);
        }


        [HttpGet]
        public async Task<IActionResult> GetPagedList([FromQuery] ProductGetPagedListQuery request, CancellationToken cancellationToken)
        {
            var productGetPagedList = await _mediator.Send(request, cancellationToken);

            return Ok(productGetPagedList);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand input, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(input, cancellationToken);
            return Ok(product);
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateCommand input, CancellationToken cancellationToken)
        {
            var updatedProduct = await _mediator.Send(input, cancellationToken);

            return Ok(updatedProduct);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] ProductDeleteCommand input, CancellationToken cancellationToken)
        {
            await _mediator.Send(input, cancellationToken);
            return Ok();
        }

    }
}
