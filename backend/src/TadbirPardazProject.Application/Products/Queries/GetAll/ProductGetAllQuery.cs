using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;

namespace TadbirPardazProject.Application.Products.Queries.GetAll
{
    public class ProductGetAllQuery : IRequest<List<ProductGetResponse>>
    {
    }
}
