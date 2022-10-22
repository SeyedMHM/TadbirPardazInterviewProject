using AutoMapper;
using TadbirPardazProject.Application.Invoices.Commands.Create;
using TadbirPardazProject.Application.Invoices.Commands.Update;
using TadbirPardazProject.Domain.Invoices;

namespace TadbirPardazProject.Application.Invoices.Commands.Common
{
    public class InvoiceCommandMappingProfile : Profile
    {
        public InvoiceCommandMappingProfile()
        {
            CreateMap<InvoiceCreateCommand, Invoice>();
            CreateMap<InvoiceDetailCreateCommand, InvoiceDetail>();

            CreateMap<InvoiceUpdateCommand, Invoice>();
            CreateMap<InvoiceDetailUpdateCommand, InvoiceDetail>();
        }
    }
}
