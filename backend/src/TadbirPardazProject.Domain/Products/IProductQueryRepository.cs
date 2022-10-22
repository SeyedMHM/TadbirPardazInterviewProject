using TadbirPardazProject.Domain.Common;

namespace TadbirPardazProject.Domain.Products
{
    public interface IProductQueryRepository
    {
        Task<Product> Get(int id, CancellationToken cancellationToken);
        Task<Product> GetAsNoTracking(int id, CancellationToken cancellationToken);
        Task<bool> IsExist(int id, CancellationToken cancellationToken);
        Task<List<Product>> GetAll(CancellationToken cancellationToken);
        Task<EntitiesWithCount<Product>> GetAllWithCount(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
