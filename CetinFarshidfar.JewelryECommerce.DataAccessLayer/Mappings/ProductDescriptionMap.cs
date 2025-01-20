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
    public class ProductDescriptionMap : IEntityTypeConfiguration<ProductDescription>
    {
        public void Configure(EntityTypeBuilder<ProductDescription> builder)
        {
            builder.HasKey(pd => pd.Id);

            builder.HasOne(pd => pd.Product)
                   .WithOne(p => p.Description)
                   .HasForeignKey<ProductDescription>(pd => pd.Id);
            builder.HasData(new ProductDescription
            {
                Id = Guid.Parse("842614F7-D402-4324-9A58-40166F4D9BB7"),
                Content = "wm_cetin@lumen.com"
            }, new ProductDescription
            {
                Id = Guid.Parse("C04595E2-2967-41EC-B7AB-D84D10C11CA0"),
                Content = "wm_cetin@lumen.com"
            });
        }
    }
}
