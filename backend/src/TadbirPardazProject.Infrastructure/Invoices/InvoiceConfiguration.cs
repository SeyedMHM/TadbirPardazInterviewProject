using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
using TadbirPardazProject.Domain.Invoices;

namespace TadbirPardazProject.Infrastructure.Invoices
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(p => p.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.HasData(SeedInvoces());
        }

        private List<Invoice> SeedInvoces()
        {
            var invoices = new List<Invoice>();
            string directoryPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string invoiceSeedPath = Path.Combine(directoryPath, @"Data/SeedData/InvoiceSeedData.json");
            using (StreamReader r = new StreamReader(invoiceSeedPath))
            {
                string json = r.ReadToEnd();
                invoices = JsonSerializer.Deserialize<List<Invoice>>(json);
            }

            return invoices ?? new();
        }
    }
}
