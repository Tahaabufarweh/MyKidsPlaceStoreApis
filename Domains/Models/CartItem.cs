using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class CartItem : BaseModel
    {
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual UserCart Cart { get; set; }
        public virtual Item Item { get; set; }
    }
}
