using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Infrastructure.Invoices
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasOne(p => p.Invoice)
                .WithMany(p=>p.InvoiceDetails)
                .HasForeignKey(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .IsRequired();

            builder.HasData(SeedInvoceDetails());
        }

        private List<InvoiceDetail> SeedInvoceDetails()
        {
            var invoiceDetails = new List<InvoiceDetail>();
            string directoryPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string invoiceDetailSeedPath = Path.Combine(directoryPath, @"Data/SeedData/InvoiceDetailSeedData.json");
            using (StreamReader r = new StreamReader(invoiceDetailSeedPath))
            {
                string json = r.ReadToEnd();
                invoiceDetails = JsonSerializer.Deserialize<List<InvoiceDetail>>(json);
            }

            return invoiceDetails ?? new();
        }
    }
}
