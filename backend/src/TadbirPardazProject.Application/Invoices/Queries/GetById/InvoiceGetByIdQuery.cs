using MediatR;
using TadbirPardazProject.Application.Invoices.Queries.Common;

namespace TadbirPardazProject.Application.Invoices.Queries.GetById
{
    public class InvoiceGetByIdQuery : IRequest<InvoiceGetResponse>
    {
        public int Id { get; set; }
    }
}
