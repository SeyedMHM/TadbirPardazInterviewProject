using TadbirPardazProject.Domain.Data;
using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Domain.Products;
using TadbirPardazProject.Infrastructure.Invoices;
using TadbirPardazProject.Infrastructure.Products;

namespace TadbirPardazProject.Infrastructure.Data
{
    public class QueryUnitOfWork : IQueryUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IProductQueryRepository _productQueryRepository;
        private IInvoiceQueryRepository _invoiceQueryRepository;

        public QueryUnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProductQueryRepository ProductQueryRepository
        {
            get
            {
                return _productQueryRepository ?? new ProductQueryRepository(_dbContext);
            }
        }
        public IInvoiceQueryRepository InvoiceQueryRepository
        {
            get
            {
                return _invoiceQueryRepository ?? new InvoiceQueryRepository(_dbContext);
            }
        }
    }
}
