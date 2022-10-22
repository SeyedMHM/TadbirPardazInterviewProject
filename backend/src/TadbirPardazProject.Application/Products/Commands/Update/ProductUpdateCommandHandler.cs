using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;
using TadbirPardazProject.Domain.Data;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Application.Products.Commands.Update
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ProductGetResponse>
    {
        private readonly ICommandUnitOfWork _commandUnitOfWork;
        private readonly IQueryUnitOfWork _queryUnitOfWork;
        private readonly IMapper _mapper;

        public ProductUpdateCommandHandler(ICommandUnitOfWork commandUnitOfWork, IQueryUnitOfWork queryUnitOfWork, IMapper mapper)
        {
            _commandUnitOfWork = commandUnitOfWork;
            _queryUnitOfWork = queryUnitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductGetResponse> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _queryUnitOfWork.ProductQueryRepository.GetAsNoTracking(request.Id, cancellationToken);
            if (product is null)
            {
                throw new KeyNotFoundException("'محصول' مورد یافت نشد");
            }

            var updatedProduct = _mapper.Map<Product>(request);
            await _commandUnitOfWork.ProductCommandRepository.Update(updatedProduct, cancellationToken);

            return _mapper.Map<ProductGetResponse>(updatedProduct);
        }
    }
}
