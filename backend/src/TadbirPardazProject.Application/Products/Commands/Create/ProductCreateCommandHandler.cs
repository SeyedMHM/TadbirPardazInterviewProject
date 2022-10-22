using AutoMapper;
using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;
using TadbirPardazProject.Domain.Data;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Application.Products.Commands.Create
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductGetResponse>
    {
        private readonly ICommandUnitOfWork _commandUnitOfWork;
        private readonly IMapper _mapper;

        public ProductCreateCommandHandler(ICommandUnitOfWork commandUnitOfWork, IMapper mapper)
        {
            _commandUnitOfWork = commandUnitOfWork;
            _mapper = mapper;
        }
        
        public async Task<ProductGetResponse> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var result = await _commandUnitOfWork.ProductCommandRepository.Add(product,cancellationToken);
            return _mapper.Map<ProductGetResponse>(result);
        }
    }
}
