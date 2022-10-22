using AutoMapper;
using TadbirPardazProject.Domain.Invoices;

namespace TadbirPardazProject.Application.Invoices.Queries.Common
{
    public class InvoiceQueriesMappingProfile : Profile
    {
        public InvoiceQueriesMappingProfile()
        {
            CreateMap<Invoice, InvoiceGetResponse>();
            CreateMap<InvoiceDetail, InvoiceDetailGetResponse>();
        }
    }
}
