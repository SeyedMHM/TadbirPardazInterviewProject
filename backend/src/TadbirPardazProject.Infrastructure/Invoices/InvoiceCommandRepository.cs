using Microsoft.EntityFrameworkCore;
using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Infrastructure.Data;

namespace TadbirPardazProject.Infrastructure.Invoices
{
    public class InvoiceCommandRepository : IInvoiceCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceCommandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Invoice> Add(Invoice invoice, CancellationToken cancellationToken)
        {
            await _dbContext.Invoices.AddAsync(invoice, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var invoiceWithInclude = await GetById(invoice.Id, cancellationToken);

            return invoiceWithInclude;
        }


        public async Task<Invoice> Update(Invoice invoice, CancellationToken cancellationToken)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            await DeleteInvoceDetails(invoice.Id, cancellationToken);
            _dbContext.Invoices.Update(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            var invoiceWithInclude = await GetById(invoice.Id, cancellationToken);

            return invoiceWithInclude;
        }


        private async Task DeleteInvoceDetails(int invoiceId, CancellationToken cancellationToken)
        {
            var invoiceDetailIds = await _dbContext.InvoiceDetails
                .Where(q => q.InvoiceId == invoiceId)
                .ToListAsync(cancellationToken);

            foreach (var item in invoiceDetailIds)
            {
                _dbContext.InvoiceDetails.Remove(item);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }


        private async Task<Invoice> GetById(int id, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.Where(q => q.Id == id)
                 .Include(q => q.InvoiceDetails).ThenInclude(q => q.Product)
                 .FirstOrDefaultAsync(cancellationToken);

            return invoice;
        }


        public async Task Delete(Invoice invoice, CancellationToken cancellationToken)
        {
            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }


        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            Invoice invoice = await _dbContext.Invoices.FindAsync(new object[] { id }, cancellationToken);

            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
