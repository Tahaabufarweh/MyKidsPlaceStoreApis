using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class Item : BaseModel
    {
        public Item()
        {
            CartItem = new HashSet<CartItem>();
            ItemColors = new HashSet<ItemColors>();
            ItemImages = new HashSet<ItemImages>();
            ItemSizes = new HashSet<ItemSizes>();
            Sale = new HashSet<Sale>();
        }

        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int ItemCount { get; set; }
        public bool IsSet { get; set; }
        public int? SetId { get; set; }
        public int Gender { get; set; }
        public string DescriptionAr { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Set Set { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<ItemColors> ItemColors { get; set; }
        public virtual ICollection<ItemImages> ItemImages { get; set; }
        public virtual ICollection<ItemSizes> ItemSizes { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
