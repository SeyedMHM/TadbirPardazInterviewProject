using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Invoices.Queries.Common;
using TadbirPardazProject.Domain.Data;

namespace TadbirPardazProject.Application.Invoices.Queries.GetById
{
    public class InvoiceGetByIdQueryHandler : IRequestHandler<InvoiceGetByIdQuery, InvoiceGetResponse>
    {
        private readonly IQueryUnitOfWork _queryUnitOfWork;
        private readonly IMapper _mapper;

        public InvoiceGetByIdQueryHandler(IQueryUnitOfWork queryUnitOfWork, IMapper mapper)
        {
            _queryUnitOfWork = queryUnitOfWork;
            _mapper = mapper;
        }

        public async Task<InvoiceGetResponse> Handle(InvoiceGetByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _queryUnitOfWork.InvoiceQueryRepository.GetAsNoTracking(request.Id, cancellationToken);
            
            return _mapper.Map<InvoiceGetResponse>(product);
        }
    }
}
