using TadbirPardazProject.Domain.Common;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Domain.Invoices
{
    public interface IInvoiceQueryRepository
    {
        Task<Invoice> Get(int id, CancellationToken cancellationToken);
        Task<Invoice> GetAsNoTracking(int id, CancellationToken cancellationToken);
        Task<bool> IsExist(int id, CancellationToken cancellationToken);
        Task<List<Invoice>> GetAll(CancellationToken cancellationToken);
        Task<EntitiesWithCount<Invoice>> GetAllWithCount(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
