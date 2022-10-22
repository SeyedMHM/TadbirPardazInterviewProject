using AutoMapper;
using TadbirPardazProject.Application.Products.Commands.Create;
using TadbirPardazProject.Application.Products.Commands.Update;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Application.Products.Commands.Common
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductCreateCommand, Product>();
            CreateMap<ProductUpdateCommand, Product>();
        }
    }
}
