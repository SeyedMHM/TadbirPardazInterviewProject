
namespace TadbirPardazProject.Domain.Invoices
{
    public interface IInvoiceCommandRepository
    {
        Task<Invoice> Add(Invoice invoice, CancellationToken cancellationToken);
        Task<Invoice> Update(Invoice invoice, CancellationToken cancellationToken);
        Task Delete(Invoice invoice, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
