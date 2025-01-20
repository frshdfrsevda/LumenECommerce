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
    public class ProductTagMap : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            // Anahtar tanımlama
            builder.HasKey(pt => pt.Id);


            builder.Property(pt => pt.ProductId)
                   .IsRequired();

            builder.Property(pt => pt.TagId)
                   .IsRequired();

            // İlişkiler
            builder.HasOne(pt => pt.Tag)
                   .WithMany(t => t.ProductTags)
                   .HasForeignKey(pt => pt.TagId);

            builder.HasOne(pt => pt.Product)
                   .WithMany(p => p.ProductTags)
                   .HasForeignKey(pt => pt.ProductId);

            // Örnek veri ekleme
            builder.HasData(
                new ProductTag
                {
                    Id = 1,
                    TagId = 2,
                    ProductId = Guid.Parse("842614F7-D402-4324-9A58-40166F4D9BB7")
                },
                new ProductTag
                {
                    Id = 2,
                    TagId = 7,
                    ProductId = Guid.Parse("842614F7-D402-4324-9A58-40166F4D9BB7")
                },
                new ProductTag
                {
                    Id = 3,
                    TagId = 11,
                    ProductId = Guid.Parse("C04595E2-2967-41EC-B7AB-D84D10C11CA0")
                }
            );
        }
    }
}
