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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C"),
                RoleId = Guid.Parse("16EA936C-7A28-4C30-86A2-9A9704B6115E")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
                RoleId = Guid.Parse("46C31BB2-9D7C-4424-9CC2-84892B055C43")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("5F3ED54B-6C06-4A22-B2E1-BADD8E0D285B"),
                RoleId = Guid.Parse("7CB750CF-3612-4FB4-9F7D-A38BA8F16BF4")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("A18DC8F2-DEFD-4233-9A37-8D12564E00BC"),
                RoleId = Guid.Parse("7CB750CF-3612-4FB4-9F7D-A38BA8F16BF4")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("E6DEF87B-C734-4A10-A0BE-CED4A542D54C"),
                RoleId = Guid.Parse("EDF6C246-41D8-475F-8D92-41DDDAC3AEFB")
            });
        }
    }
}
