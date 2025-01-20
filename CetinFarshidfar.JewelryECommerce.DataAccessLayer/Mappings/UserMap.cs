using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.DataAccessLayer.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var superadmin = new AppUser
            {
                Id = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C"),
                UserName = "wm_cetin@lumen.com",
                NormalizedUserName = "WM_CETIN@LUMEN.COM",
                Email = "wm_cetin@lumen.com",
                NormalizedEmail = "WM_CETIN@LUMEN.COM",
                PhoneNumber = "+905356236286",
                FullName = "Muhammed Emin Çetin",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            superadmin.PasswordHash = CreatePasswordHash(superadmin, "123456");

            var supportMod = new AppUser
            {
                Id = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
                UserName = "sup_farshidfarsevda@lumen.com",
                NormalizedUserName = "SUP_FARSHIDFARSEVDA@LUMEN.COM",
                Email = "sup_farshidfarsevda@lumen.com",
                NormalizedEmail = "SUP_FARSHIDFARSEVDA@LUMEN.COM",
                PhoneNumber = "+905439999988",
                FullName = "Sevda Farshidfar",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            supportMod.PasswordHash = CreatePasswordHash(supportMod, "123456");

            var companyMod1 = new AppUser
            {
                Id = Guid.Parse("5F3ED54B-6C06-4A22-B2E1-BADD8E0D285B"),
                UserName = "com_rizasarraf@lumen.com",
                NormalizedUserName = "COM_RIZASARRAF@LUMEN.COM",
                Email = "com_rizasarraf@lumen.com",
                NormalizedEmail = "COM_RIZASARRAF@LUMEN.COM",
                PhoneNumber = "+905439999988",
                FullName = "Rıza Sarraf",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            companyMod1.PasswordHash = CreatePasswordHash(companyMod1, "123456");

            var companyMod2 = new AppUser
            {
                Id = Guid.Parse("A18DC8F2-DEFD-4233-9A37-8D12564E00BC"),
                UserName = "com_alialtinkafa@lumen.com",
                NormalizedUserName = "COM_ALIALTINKAFA@LUMEN.COM",
                Email = "com_alialtinkafa@lumen.com",
                NormalizedEmail = "COM_ALIALTINKAFA@LUMEN.COM",
                PhoneNumber = "+905439999988",
                FullName = "Ali Altınkafa",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            companyMod2.PasswordHash = CreatePasswordHash(companyMod2, "123456");


            var user = new AppUser
            {
                Id = Guid.Parse("E6DEF87B-C734-4A10-A0BE-CED4A542D54C"),
                UserName = "mami22cetin@gmail.com",
                NormalizedUserName = "MAMI22CETIN@GMAIL.COM",
                Email = "mami22cetin@gmail.com",
                NormalizedEmail = "MAMI22CETIN@GMAIL.COM",
                PhoneNumber = "+905439999988",
                FullName = "Fatma Kara",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = CreatePasswordHash(user, "123456");

            builder.HasData(superadmin, supportMod, companyMod1, companyMod2, user);

        }
        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
