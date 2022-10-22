using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Invoices.Queries.Common;
using TadbirPardazProject.Domain.Data;

namespace TadbirPardazProject.Application.Invoices.Queries.GetAll
{
    public class InvoiceGetAllQueryHandler : IRequestHandler<InvoiceGetAllQuery, List<InvoiceGetResponse>>
    {
        private readonly IQueryUnitOfWork _queryUnitOfWork;
        private readonly IMapper _mapper;

        public InvoiceGetAllQueryHandler(IQueryUnitOfWork queryUnitOfWork, IMapper mapper)
        {
            _queryUnitOfWork = queryUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<InvoiceGetResponse>> Handle(InvoiceGetAllQuery request, CancellationToken cancellationToken)
        {
            var products = await _queryUnitOfWork.InvoiceQueryRepository.GetAll(cancellationToken);
            return _mapper.Map<List<InvoiceGetResponse>>(products);
        }
    }
}