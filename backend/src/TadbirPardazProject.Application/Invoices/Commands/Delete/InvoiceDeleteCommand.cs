using MediatR;

namespace TadbirPardazProject.Application.Invoices.Commands.Delete
{
    public class InvoiceDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
