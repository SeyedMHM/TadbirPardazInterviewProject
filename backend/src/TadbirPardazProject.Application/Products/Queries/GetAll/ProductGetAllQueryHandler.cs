using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;
using TadbirPardazProject.Domain.Data;

namespace TadbirPardazProject.Application.Products.Queries.GetAll
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, List<ProductGetResponse>>
    {
        private readonly IQueryUnitOfWork _queryUnitOfWork;
        private readonly IMapper _mapper;

        public ProductGetAllQueryHandler(IQueryUnitOfWork queryUnitOfWork, IMapper mapper)
        {
            _queryUnitOfWork = queryUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductGetResponse>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var products = await _queryUnitOfWork.ProductQueryRepository.GetAll(cancellationToken);
            return _mapper.Map<List<ProductGetResponse>>(products);
        }
    }
}
