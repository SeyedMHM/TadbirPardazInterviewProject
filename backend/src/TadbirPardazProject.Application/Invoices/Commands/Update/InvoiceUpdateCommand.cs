using MediatR;
using TadbirPardazProject.Application.Invoices.Queries.Common;
using TadbirPardazProject.Common.Utilities;

namespace TadbirPardazProject.Application.Invoices.Commands.Update
{
    public class InvoiceUpdateCommand : IRequest<InvoiceGetResponse>
    {
        public int Id { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedDatePersian
        {
            get => IssuedDate.ToPersianDate();
            set => IssuedDate = value.ToDateTime();
        }

        public string CustomerName { get; set; }
        public string? Description { get; set; }
        public List<InvoiceDetailUpdateCommand> InvoiceDetails { get; set; }
    }

    public class InvoiceDetailUpdateCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercent { get; set; }
    }
}
