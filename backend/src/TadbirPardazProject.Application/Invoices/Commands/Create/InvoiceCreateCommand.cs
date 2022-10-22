using MediatR;
using TadbirPardazProject.Application.Invoices.Queries.Common;
using TadbirPardazProject.Common.Utilities;

namespace TadbirPardazProject.Application.Invoices.Commands.Create
{
    public class InvoiceCreateCommand : IRequest<InvoiceGetResponse>
    {
        public DateTime IssuedDate { get; set; }
        public string IssuedDatePersian
        {
            get => IssuedDate.ToPersianDate();
            set => IssuedDate = value.ToDateTime();
        }

        public string CustomerName { get; set; }
        public string? Description { get; set; }
        public List<InvoiceDetailCreateCommand> InvoiceDetails { get; set; }
    }

    public class InvoiceDetailCreateCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercent { get; set; }
    }
}
