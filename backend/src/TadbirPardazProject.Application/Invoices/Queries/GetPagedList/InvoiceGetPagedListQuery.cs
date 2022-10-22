using MediatR;
using TadbirPardazProject.Application.Invoices.Queries.Common;
using TadbirPardazProject.Shared.Common.ApiResults;

namespace TadbirPardazProject.Application.Invoices.Queries.GetPagedList
{
    public class InvoiceGetPagedListQuery : PagedListMetadata, IRequest<PagedList<InvoiceGetResponse>>
    {
    }
}
