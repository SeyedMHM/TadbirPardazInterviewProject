using TadbirPardazProject.Domain.Products;
using TadbirPardazProject.Infrastructure.Data;

namespace TadbirPardazProject.Infrastructure.Products
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCommandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Add(Product product, CancellationToken cancellationToken)
        {
            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product> Update(Product product, CancellationToken cancellationToken)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task Delete(Product product, CancellationToken cancellationToken)
        {
            product.IsDeleted = true;
            
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            Product product = await _dbContext.Products.FindAsync(new object[] { id }, cancellationToken);
            product.IsDeleted = true;

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
