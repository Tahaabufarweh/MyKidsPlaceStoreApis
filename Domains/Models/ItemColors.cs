using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class ItemColors : BaseModel
    {
        public int ColorId { get; set; }
        public int ItemId { get; set; }

        public virtual Colour Color { get; set; }
        public virtual Item Item { get; set; }
    }
}
