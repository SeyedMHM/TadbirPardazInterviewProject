using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;
using TadbirPardazProject.Domain.Data;

namespace TadbirPardazProject.Application.Products.Queries.GetById
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQuery, ProductGetResponse>
    {
        private readonly IQueryUnitOfWork _queryUnitOfWork;
        private readonly IMapper _mapper;

        public ProductGetByIdQueryHandler(IQueryUnitOfWork queryUnitOfWork, IMapper mapper)
        {
            _queryUnitOfWork = queryUnitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductGetResponse> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _queryUnitOfWork.ProductQueryRepository.GetAsNoTracking(request.Id, cancellationToken);
            
            return _mapper.Map<ProductGetResponse>(product);
        }
    }
}
