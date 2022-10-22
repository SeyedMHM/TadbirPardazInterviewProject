using TadbirPardazProject.Domain.Common;

namespace TadbirPardazProject.Domain.Invoices
{
    public class Invoice : BaseEntity
    {
        public DateTime IssuedDate { get; set; }
        public string CustomerName { get; set; }
        public string? Description { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
