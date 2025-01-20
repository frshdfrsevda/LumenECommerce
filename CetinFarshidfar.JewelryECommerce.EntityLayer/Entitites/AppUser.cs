using CetinFarshidfar.JewelryECommerce.CoreLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FullName { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.Now;
    }
}
