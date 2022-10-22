using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;

namespace TadbirPardazProject.Application.Products.Commands.Create
{
    public class ProductCreateCommand : IRequest<ProductGetResponse>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
