using MediatR;
using Microsoft.AspNetCore.Mvc;
using TadbirPardazProject.Application.Invoices.Commands.Create;
using TadbirPardazProject.Application.Invoices.Commands.Delete;
using TadbirPardazProject.Application.Invoices.Commands.Update;
using TadbirPardazProject.Application.Invoices.Queries.Common;
using TadbirPardazProject.Application.Invoices.Queries.GetAll;
using TadbirPardazProject.Application.Invoices.Queries.GetById;
using TadbirPardazProject.Application.Invoices.Queries.GetPagedList;
using TadbirPardazProject.Shared.Api.Filters;

namespace TadbirPardazProject.Endpoint.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ApiResultFilter]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InvoiceGetByIdQuery input, CancellationToken cancellationToken)
        {
            var invoice = await _mediator.Send(input, cancellationToken);

            if (invoice is null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] InvoiceGetAllQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _mediator.Send(request, cancellationToken);

            return Ok(invoices);
        }


        [HttpGet]
        public async Task<IActionResult> GetPagedList([FromQuery] InvoiceGetPagedListQuery request, CancellationToken cancellationToken)
        {
            var invoiceGetPagedList = await _mediator.Send(request, cancellationToken);

            return Ok(invoiceGetPagedList);
        }


        [HttpPost]
        public async Task<IActionResult> Create(InvoiceCreateCommand input, CancellationToken cancellationToken)
        {
            var invoice = await _mediator.Send(input, cancellationToken);
            return Ok(invoice);
        }


        [HttpPut]
        public async Task<IActionResult> Update(InvoiceUpdateCommand input, CancellationToken cancellationToken)
        {
            var updatedInvoice = await _mediator.Send(input, cancellationToken);

            return Ok(updatedInvoice);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(InvoiceDeleteCommand input, CancellationToken cancellationToken)
        {
            await _mediator.Send(input, cancellationToken);
            return Ok();
        }
    
    }
}
