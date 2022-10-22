using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Domain.Data
{
    public interface ICommandUnitOfWork
    {
        IProductCommandRepository ProductCommandRepository { get; }
        IInvoiceCommandRepository InvoiceCommandRepository { get; }
    }
}
