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
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.ParentTagId);
            builder.HasOne(t => t.ParentTag).WithMany(t => t.ChildTags).HasForeignKey(t => t.ParentTagId);
            builder.HasData(new Tag
            {
                Id = 1,
                Name = "Malzeme"
            }, new Tag
            {
                Id = 2,
                Name = "Altın",
                ParentTagId = 1
            }, new Tag
            {
                Id = 3,
                Name = "Gümüş",
                ParentTagId = 1
            }, new Tag
            {
                Id = 4,
                Name = "Elmas",
                ParentTagId = 1
            }, new Tag
            {
                Id = 5,
                Name = "Zümrüt",
                ParentTagId = 1
            }, new Tag
            {
                Id = 6,
                Name = "Renk"
            }, new Tag
            {
                Id = 7,
                Name = "Sarı Altın",
                ParentTagId = 6
            }, new Tag
            {
                Id = 8,
                Name = "Beyaz Altın",
                ParentTagId = 6
            }, new Tag
            {
                Id = 9,
                Name = "Rose Altın",
                ParentTagId = 6
            }, new Tag
            {
                Id = 10,
                Name = "Tarz"
            }, new Tag
            {
                Id = 11,
                Name = "Modern",
                ParentTagId = 10
            }, new Tag
            {
                Id = 12,
                Name = "Klasik",
                ParentTagId = 10
            }, new Tag
            {
                Id = 13,
                Name = "Vintage",
                ParentTagId = 10
            });
        }
    }
}
