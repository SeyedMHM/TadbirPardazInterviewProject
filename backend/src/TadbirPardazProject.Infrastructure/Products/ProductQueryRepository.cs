using Microsoft.EntityFrameworkCore;
using TadbirPardazProject.Domain.Common;
using TadbirPardazProject.Domain.Products;
using TadbirPardazProject.Infrastructure.Common.Extensions;
using TadbirPardazProject.Infrastructure.Data;

namespace TadbirPardazProject.Infrastructure.Products
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private IQueryable<Product> _productQuery;
        public ProductQueryRepository(ApplicationDbContext dbContext)
        {
            _productQuery = dbContext.Products.Where(q => !q.IsDeleted);
        }


        public async Task<Product> Get(int id, CancellationToken cancellationToken)
        {
            return await _productQuery.Where(q => q.Id == id).FirstOrDefaultAsync(cancellationToken);
        }


        /// <summary>
        /// When we retrieve an item from the database, the item an attached into DbContext. 
        /// For the reason, when we update it's necessery to the item AsNoTracking
        /// </summary>
        /// <returns>Get Product from Db but not attached to DbContext</returns>
        public async Task<Product> GetAsNoTracking(int id, CancellationToken cancellationToken)
        {
            return await _productQuery.Where(q => q.Id == id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }


        public async Task<bool> IsExist(int id, CancellationToken cancellationToken)
        {
            return await _productQuery.Where(q => q.Id == id).AsNoTracking().AnyAsync(cancellationToken);
        }


        public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
        {
            return await _productQuery.AsNoTracking().ToListAsync(cancellationToken);
        }


        public async Task<EntitiesWithCount<Product>> GetAllWithCount(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var entitiesWithCount = await _productQuery.AsNoTracking()
                .ToEntityWithCount<Product>(pageNumber, pageSize, cancellationToken);

            return entitiesWithCount;
        }
    }
}
