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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.ParentCategoryId);
            builder.HasOne(t => t.ParentCategory).WithMany(t => t.ChildCategories).HasForeignKey(t => t.ParentCategoryId);
            builder.HasData(new Category
            {
                Id = Guid.Parse("C12817DD-6B83-46E0-8020-54095E11ED5B"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "Bileklikler"
            }, new Category
            {
                Id = Guid.Parse("03CE06EA-9051-4E0A-B444-2D19CDEBD94B"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "Altın Bileklikler",
                ParentCategoryId = Guid.Parse("C12817DD-6B83-46E0-8020-54095E11ED5B")
            }, new Category
            {
                Id = Guid.Parse("F0CBFC44-2FA5-4E8C-A6CC-E508B9F57842"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "Taşlı Bileklikler",
                ParentCategoryId = Guid.Parse("C12817DD-6B83-46E0-8020-54095E11ED5B")
            }, new Category
            {
                Id = Guid.Parse("BC969756-0930-4EE7-BE16-A5AE1A83213C"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "Kolyeler"
            }, new Category
            {
                Id = Guid.Parse("D78BF8DE-9D79-4BA0-9B62-7252C9738FDB"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "İnci Kolyeler",
                ParentCategoryId = Guid.Parse("BC969756-0930-4EE7-BE16-A5AE1A83213C")
            }, new Category
            {
                Id = Guid.Parse("91904860-0D46-479B-B423-E80E4D11207B"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "Altın Kolyeler",
                ParentCategoryId = Guid.Parse("BC969756-0930-4EE7-BE16-A5AE1A83213C")
            }, new Category
            {
                Id = Guid.Parse("64F6D36F-8F31-4850-B8AD-9F36F1E730AC"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "Pırlanta Kolyeler",
                ParentCategoryId = Guid.Parse("BC969756-0930-4EE7-BE16-A5AE1A83213C")
            });
        }
    }
}
