using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Domain.Data
{
    public interface IQueryUnitOfWork
    {
        IProductQueryRepository ProductQueryRepository { get; }
        IInvoiceQueryRepository InvoiceQueryRepository { get; }
    }
}