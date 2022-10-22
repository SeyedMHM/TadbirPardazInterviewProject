using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;
using TadbirPardazProject.Shared.Common.ApiResults;

namespace TadbirPardazProject.Application.Products.Queries.GetPagedList
{
    public class ProductGetPagedListQuery : PagedListMetadata, IRequest<PagedList<ProductGetResponse>>
    {
    }
}
