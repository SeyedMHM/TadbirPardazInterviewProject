using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
using TadbirPardazProject.Domain.Products;

namespace TadbirPardazProject.Infrastructure.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18,0);

            builder.HasData(SeedProducts());
        }

        private List<Product> SeedProducts()
        {
            var products = new List<Product>();
            string directoryPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string productSeedPath = Path.Combine(directoryPath, @"Data/SeedData/ProductSeedData.json");
            using (StreamReader r = new StreamReader(productSeedPath))
            {
                string json = r.ReadToEnd();
                products = JsonSerializer.Deserialize<List<Product>>(json);
            }

            return products ?? new();
        }
    }
}
