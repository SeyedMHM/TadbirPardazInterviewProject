using MediatR;
using TadbirPardazProject.Application.Invoices.Queries.Common;

namespace TadbirPardazProject.Application.Invoices.Queries.GetAll
{
    public class InvoiceGetAllQuery : IRequest<List<InvoiceGetResponse>>
    {
    }
}
