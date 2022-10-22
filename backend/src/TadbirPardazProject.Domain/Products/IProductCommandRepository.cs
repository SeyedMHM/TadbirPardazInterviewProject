namespace TadbirPardazProject.Domain.Products
{
    public interface IProductCommandRepository
    {
        Task<Product> Add(Product product, CancellationToken cancellationToken);
        Task<Product> Update(Product product, CancellationToken cancellationToken);
        Task Delete(Product product, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
