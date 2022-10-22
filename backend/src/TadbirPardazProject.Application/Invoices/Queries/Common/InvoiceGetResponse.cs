using TadbirPardazProject.Common.Utilities;

namespace TadbirPardazProject.Application.Invoices.Queries.Common
{
    public class InvoiceGetResponse
    {
        public int Id { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedDatePersian
        {
            get => IssuedDate.ToPersianDate();
            set => IssuedDate = value.ToDateTime();
        }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public List<InvoiceDetailGetResponse> InvoiceDetails { get; set; } = new List<InvoiceDetailGetResponse>();

        public decimal SumOfPrice => InvoiceDetails.Select(q => q.SumOfProductPrice).DefaultIfEmpty(0).Sum();
        public decimal SumOfDiscount => InvoiceDetails.Select(q => q.SumOfCustomerProfit).DefaultIfEmpty(0).Sum();
        public decimal FinalAmount => SumOfPrice - SumOfDiscount;
    }
}
