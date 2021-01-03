using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class Orders: BaseModel
    {
        public Orders()
        {
            CartItem = new HashSet<CartItem>();
        }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime ModifiedBy { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
