using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class CartItem : BaseModel
    {
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int? OrderId { get; set; }

        public virtual UserCart Cart { get; set; }
        public virtual Item Item { get; set; }
        public virtual Orders Order { get; set; }
    }
}
