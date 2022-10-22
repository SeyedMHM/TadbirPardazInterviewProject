using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Common.Exceptions;
using TadbirPardazProject.Application.Invoices.Queries.Common;
using TadbirPardazProject.Domain.Data;
using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Shared.Common.ApiResults;

namespace TadbirPardazProject.Application.Invoices.Queries.GetPagedList
{
    public class InvoiceGetPagedListQueryHandler : IRequestHandler<InvoiceGetPagedListQuery, PagedList<InvoiceGetResponse>>
    {
        private readonly IQueryUnitOfWork _queryUnitOfWork;
        private readonly IMapper _mapper;

        public InvoiceGetPagedListQueryHandler(IQueryUnitOfWork queryUnitOfWork, IMapper mapper)
        {
            _queryUnitOfWork = queryUnitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<InvoiceGetResponse>> Handle(InvoiceGetPagedListQuery request, CancellationToken cancellationToken)
        {
            var entitiesWithCount = await _queryUnitOfWork.InvoiceQueryRepository
                .GetAllWithCount(request.PageId, request.PageSize, cancellationToken);

            var productsPagedList =  entitiesWithCount.ToPagedResult<Invoice, InvoiceGetResponse>(_mapper, request.PageId, request.PageSize);

            return productsPagedList;
        }
    }
}
