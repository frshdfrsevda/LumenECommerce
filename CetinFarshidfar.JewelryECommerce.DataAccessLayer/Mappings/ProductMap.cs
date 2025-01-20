using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.DataAccessLayer.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Anahtar tanımlama
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Price).HasPrecision(18, 2); // Precision ve Scale belirtildi

            // İlişkileri tanımlama
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.Company)
                   .WithMany()
                   .HasForeignKey(p => p.CompanyId);

            builder.HasOne(p => p.Description)
                   .WithOne(d => d.Product)
                   .HasForeignKey<ProductDescription>(d => d.Id);
            builder.HasData(
            new Product
            {
                Id = Guid.Parse("842614F7-D402-4324-9A58-40166F4D9BB7"),
                ProductCode = "P001",
                Name = "Altın Kelepçe, 24 Ayar 25 Gr Altın",
                SpecialProduction = false,
                StockQuantity = 100,
                Price = 80000.00m,
                DiscountPercentage = null,
                EstimatedShippingTime = 3,
                CategoryId = Guid.Parse("03CE06EA-9051-4E0A-B444-2D19CDEBD94B"),
                CompanyId = Guid.Parse("130AB18E-E4B8-4769-AC84-4BB8C4153F4C"),
                CreatedBy = "com_rizasarraf@lumen.com"
            },
            new Product
            {
                Id = Guid.Parse("C04595E2-2967-41EC-B7AB-D84D10C11CA0"),
                ProductCode = "P002",
                Name = "Pırlanta Kolye, 0.33 Karat Özel Tasarım",
                SpecialProduction = true,
                StockQuantity = 5,
                Price = 20000.00m,
                DiscountPercentage = 4,
                EstimatedShippingTime = 3,
                CategoryId = Guid.Parse("64F6D36F-8F31-4850-B8AD-9F36F1E730AC"),
                CompanyId = Guid.Parse("130AB18E-E4B8-4769-AC84-4BB8C4153F4C"),
                CreatedBy = "com_rizasarraf@lumen.com"
            }
        );
        }
    }
}
