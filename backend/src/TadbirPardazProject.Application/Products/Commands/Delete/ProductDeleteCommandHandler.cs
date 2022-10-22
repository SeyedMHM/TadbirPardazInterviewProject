using MediatR;
using TadbirPardazProject.Domain.Data;

namespace TadbirPardazProject.Application.Products.Commands.Delete
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, Unit>
    {
        private readonly ICommandUnitOfWork _commandUnitOfWork;
        private readonly IQueryUnitOfWork _queryUnitOfWork;

        public ProductDeleteCommandHandler(ICommandUnitOfWork commandUnitOfWork, 
            IQueryUnitOfWork queryUnitOfWork)
        {
            _commandUnitOfWork = commandUnitOfWork;
            _queryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Unit> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var productIsExist = await _queryUnitOfWork.ProductQueryRepository.IsExist(request.Id, cancellationToken);
            if (!productIsExist)
            {
                throw new KeyNotFoundException("'محصول' مورد یافت نشد");
            }

            await _commandUnitOfWork.ProductCommandRepository.Delete(request.Id, cancellationToken);

            return new Unit();
        }
    }
}
