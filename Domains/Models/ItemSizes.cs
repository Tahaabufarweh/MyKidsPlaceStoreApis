using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class ItemSizes : BaseModel
    {
        public int SizeId { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual Size Size { get; set; }
    }
}
