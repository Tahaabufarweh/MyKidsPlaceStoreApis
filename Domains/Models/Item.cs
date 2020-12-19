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
            Sale = new HashSet<Sale>();
            UserOrder = new HashSet<UserOrder>();
        }

        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public int Status { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int ItemCount { get; set; }
        public string SizesAvailable { get; set; }
        public bool IsSet { get; set; }
        public int? SetId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Set Set { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
        public virtual ICollection<UserOrder> UserOrder { get; set; }
    }
}
