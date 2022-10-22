using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Common.Exceptions;
using TadbirPardazProject.Application.Products.Queries.Common;
using TadbirPardazProject.Domain.Data;
using TadbirPardazProject.Domain.Products;
using TadbirPardazProject.Shared.Common.ApiResults;

namespace TadbirPardazProject.Application.Products.Queries.GetPagedList
{
    public class ProductGetPagedListQueryHandler : IRequestHandler<ProductGetPagedListQuery, PagedList<ProductGetResponse>>
    {
        private readonly IQueryUnitOfWork _queryUnitOfWork;
        private readonly IMapper _mapper;

        public ProductGetPagedListQueryHandler(IQueryUnitOfWork queryUnitOfWork, IMapper mapper)
        {
            _queryUnitOfWork = queryUnitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<ProductGetResponse>> Handle(ProductGetPagedListQuery request, CancellationToken cancellationToken)
        {
            var entitiesWithCount = await _queryUnitOfWork.ProductQueryRepository
                .GetAllWithCount(request.PageId, request.PageSize, cancellationToken);

            var productsPagedList =  entitiesWithCount.ToPagedResult<Product, ProductGetResponse>(_mapper, request.PageId, request.PageSize);

            return productsPagedList;
        }
    }
}
