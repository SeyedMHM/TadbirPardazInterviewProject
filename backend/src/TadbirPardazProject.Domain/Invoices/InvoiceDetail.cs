using TadbirPardazProject.Domain.Common;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Domain.Invoices
{
    public class InvoiceDetail : BaseEntity
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public byte DiscountPercent { get; set; }

        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
    }
}
