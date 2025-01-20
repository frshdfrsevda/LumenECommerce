using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.DataAccessLayer.Mappings
{
    public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // Anahtar tanımlama
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.Queue)
                   .IsRequired(false);

            // İlişkiler
            builder.HasOne(pi => pi.Product)
                   .WithMany(p => p.Images)
                   .HasForeignKey(pi => pi.ProductId);

            // Örnek veri ekleme
            builder.HasData(
                new ProductImage
                {
                    Id = 1,
                    Path = "/img/products/842614F7-D402-4324-9A58-40166F4D9BB7/EBE9E0F2-49E4-4D8B-B7C5-5A06AC25C220.jpg",
                    Queue = 1,
                    ProductId = Guid.Parse("842614F7-D402-4324-9A58-40166F4D9BB7")
                },
                new ProductImage
                {
                    Id = 2,
                    Path = "/img/products/842614F7-D402-4324-9A58-40166F4D9BB7/7FB73879-9575-4B34-AC4B-550FE2A7A212.jpg",
                    Queue = 2,
                    ProductId = Guid.Parse("842614F7-D402-4324-9A58-40166F4D9BB7")
                },
                new ProductImage
                {
                    Id = 3,
                    Path = "/img/products/C04595E2-2967-41EC-B7AB-D84D10C11CA0/2C2B225A-B9FC-411B-99E5-AB6088EAF2F4.jpg",
                    Queue = null,
                    ProductId = Guid.Parse("C04595E2-2967-41EC-B7AB-D84D10C11CA0")
                }
            );
        }
    }
}
