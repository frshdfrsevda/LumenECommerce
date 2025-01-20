using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Addresses
{
    public class AddressVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerFullName { get; set; }
        [Phone]
        public string CustomerPhone { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Detail { get; set; }
        public int ZipCode { get; set; }
    }
}
