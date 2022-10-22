using TadbirPardazProject.Domain.Common;

namespace TadbirPardazProject.Domain.Products
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
