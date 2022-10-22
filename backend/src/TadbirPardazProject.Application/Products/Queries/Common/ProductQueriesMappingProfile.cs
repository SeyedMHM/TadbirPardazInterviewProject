using AutoMapper;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Application.Products.Queries.Common
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductGetResponse>();
        }
    }
}
