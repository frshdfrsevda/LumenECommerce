using CetinFarshidfar.JewelryECommerce.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites
{
    public class Tag : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentTagId { get; set; }

        [ForeignKey("ParentTagId")]
        public virtual Tag ParentTag { get; set; }

        public virtual ICollection<Tag> ChildTags { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
