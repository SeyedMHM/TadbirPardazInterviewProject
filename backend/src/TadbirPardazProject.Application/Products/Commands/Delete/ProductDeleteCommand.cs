using MediatR;

namespace TadbirPardazProject.Application.Products.Commands.Delete
{
    public class ProductDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
