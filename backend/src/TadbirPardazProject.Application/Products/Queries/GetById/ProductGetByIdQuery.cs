using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;

namespace TadbirPardazProject.Application.Products.Queries.GetById
{
    public class ProductGetByIdQuery : IRequest<ProductGetResponse>
    {
        public int Id { get; set; }
    }
}
