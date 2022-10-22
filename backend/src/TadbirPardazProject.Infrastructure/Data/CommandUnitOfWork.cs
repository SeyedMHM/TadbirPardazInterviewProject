using TadbirPardazProject.Domain.Data;
using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Domain.Products;
using TadbirPardazProject.Infrastructure.Invoices;
using TadbirPardazProject.Infrastructure.Products;

namespace TadbirPardazProject.Infrastructure.Data
{
    public class CommandUnitOfWork : ICommandUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IProductCommandRepository _productCommandRepository;
        private IInvoiceCommandRepository _invoiceCommandRepository;

        public CommandUnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProductCommandRepository ProductCommandRepository
        {
            get
            {
                return _productCommandRepository ?? new ProductCommandRepository(_dbContext);
            }
        }

        public IInvoiceCommandRepository InvoiceCommandRepository
        {
            get
            {
                return _invoiceCommandRepository ?? new InvoiceCommandRepository(_dbContext);
            }
        }
    }
}
