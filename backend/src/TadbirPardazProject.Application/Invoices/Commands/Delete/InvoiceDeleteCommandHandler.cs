using MediatR;
using TadbirPardazProject.Domain.Data;

namespace TadbirPardazProject.Application.Invoices.Commands.Delete
{
    public class InvoiceDeleteCommandHandler : IRequestHandler<InvoiceDeleteCommand, Unit>
    {
        private readonly ICommandUnitOfWork _commandUnitOfWork;
        private readonly IQueryUnitOfWork _queryUnitOfWork;

        public InvoiceDeleteCommandHandler(ICommandUnitOfWork commandUnitOfWork, 
            IQueryUnitOfWork queryUnitOfWork)
        {
            _commandUnitOfWork = commandUnitOfWork;
            _queryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Unit> Handle(InvoiceDeleteCommand request, CancellationToken cancellationToken)
        {
            var InvoiceIsExist = await _queryUnitOfWork.InvoiceQueryRepository.IsExist(request.Id, cancellationToken);
            if (!InvoiceIsExist)
            {
                throw new KeyNotFoundException("'فاکتور' مورد یافت نشد");
            }

            await _commandUnitOfWork.InvoiceCommandRepository.Delete(request.Id, cancellationToken);

            return new Unit();
        }
    }
}
