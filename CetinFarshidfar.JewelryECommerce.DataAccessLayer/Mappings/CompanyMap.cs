using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.DataAccessLayer.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.CoFounder).WithMany().HasForeignKey(c => c.CoFounderId);
            builder.HasIndex(u => u.CoFounderId);

            builder.HasData(new Company
            {
                Id = Guid.Parse("130AB18E-E4B8-4769-AC84-4BB8C4153F4C"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "Sarraf Jewelry",
                Address = "1920 DR MARTIN L KING JR BLVD",
                City = "New York",
                State = "BRONX",
                PostalCode = "10453-4416",
                Country = "USA",
                Phone = "555-5971-3152",
                Email = "sarraf@jewelry.com",
                FoundedDate = CreateFoundedDate(),
                NumberOfEmployees = CreateNumberOfEmployees(),
                Industry = "Jewelry",
                Description = "We are a premier jewelry company dedicated to creating exquisite pieces that embody elegance and timeless beauty. Our collection features meticulously crafted jewelry designed to make every moment sparkle. From classic designs to contemporary masterpieces, each piece is a testament to our commitment to quality and craftsmanship.",
                CoFounderId = Guid.Parse("5F3ED54B-6C06-4A22-B2E1-BADD8E0D285B")
            }, new Company
            {
                Id = Guid.Parse("0B5253C9-4495-4948-946D-C2FDBCE74476"),
                CreatedBy = "wm_cetin@lumen.com",
                Name = "AltınKafa Mücevherat",
                Address = "Davutpaşa mh. 62.sk No:67",
                City = "İstanbul",
                State = "Esenler",
                PostalCode = "34230",
                Country = "Türkiye",
                Phone = "212-202-3030",
                Email = "altinkafa@mucevherat.com",
                FoundedDate = CreateFoundedDate(),
                NumberOfEmployees = CreateNumberOfEmployees(),
                Industry = "Mücevherat",
                Description = "Şirketimiz, zarafet ve zamansız güzelliği temsil eden muhteşem mücevherler yaratmaya adanmıştır. Koleksiyonumuz, her anınızı parlatmak için özenle tasarlanmış mücevherlerden oluşmaktadır. Klasik tasarımlardan modern başyapıtlara kadar her parça, kalite ve işçilik konusundaki bağlılığımızın bir kanıtıdır.\r\n",
                CoFounderId = Guid.Parse("A18DC8F2-DEFD-4233-9A37-8D12564E00BC")
            });
        }
        private int CreateNumberOfEmployees()
        {
            Random random = new Random();
            return random.Next(5, 1000);
        }
        private DateTime CreateFoundedDate()
        {
            Random random = new Random();
            DateTime startDate = new DateTime(1900, 1, 1); // Rastgele tarih için başlangıç noktası
            DateTime endDate = DateTime.Now; // Şu anki tarih
            int range = (endDate - startDate).Days; // Başlangıç ve şu anki tarih arasındaki gün farkı

            return startDate.AddDays(random.Next(range)).AddSeconds(random.Next(86400)); // Gün ve saniye ekle
        }
    }
}
