using MediatR;
using TadbirPardazProject.Application.Products.Queries.Common;

namespace TadbirPardazProject.Application.Products.Commands.Update
{
    public class ProductUpdateCommand : IRequest<ProductGetResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
