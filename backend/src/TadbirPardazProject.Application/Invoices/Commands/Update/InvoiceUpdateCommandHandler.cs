using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Invoices.Queries.Common;
using TadbirPardazProject.Domain.Data;
using TadbirPardazProject.Domain.Invoices;

namespace TadbirPardazProject.Application.Invoices.Commands.Update
{
    public class InvoiceUpdateCommandHandler : IRequestHandler<InvoiceUpdateCommand, InvoiceGetResponse>
    {
        private readonly ICommandUnitOfWork _commandUnitOfWork;
        private readonly IMapper _mapper;

        public InvoiceUpdateCommandHandler(ICommandUnitOfWork commandUnitOfWork, IMapper mapper)
        {
            _commandUnitOfWork = commandUnitOfWork;
            _mapper = mapper;
        }

        public async Task<InvoiceGetResponse> Handle(InvoiceUpdateCommand request, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Invoice>(request);

            var result = await _commandUnitOfWork.InvoiceCommandRepository.Update(invoice, cancellationToken);

            return _mapper.Map<InvoiceGetResponse>(result);
        }
    }
}
