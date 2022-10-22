using Microsoft.EntityFrameworkCore;
using TadbirPardazProject.Domain.Common;
using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Infrastructure.Common.Extensions;
using TadbirPardazProject.Infrastructure.Data;

namespace TadbirPardazProject.Infrastructure.Invoices
{
    public class InvoiceQueryRepository : IInvoiceQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceQueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Invoice> Get(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices
                .Include(e => e.InvoiceDetails).ThenInclude(e => e.Product)
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }


        /// <summary>
        /// When we retrieve an item from the database, the item an attached into DbContext. 
        /// For the reason, when we update it's necessery to the item AsNoTracking
        /// </summary>
        /// <returns>Get Product from Db but not attached to DbContext</returns>
        public async Task<Invoice> GetAsNoTracking(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices
                .Include(e => e.InvoiceDetails).ThenInclude(e => e.Product)
                .Where(q => q.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }


        public async Task<bool> IsExist(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices
                .Where(q => q.Id == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);
        }


        public async Task<List<Invoice>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices
                .Include(e => e.InvoiceDetails).ThenInclude(e => e.Product)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }


        public async Task<EntitiesWithCount<Invoice>> GetAllWithCount(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var entitiesWithCount = await _dbContext.Invoices
                .Include(e => e.InvoiceDetails).ThenInclude(e=>e.Product)
                .AsNoTracking()
                .ToEntityWithCount<Invoice>(pageNumber, pageSize, cancellationToken);

            return entitiesWithCount;
        }
    }
}
