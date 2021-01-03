using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class Size: BaseModel
    {
        public Size()
        {
            ItemSizes = new HashSet<ItemSizes>();
        }

        public string Size1 { get; set; }

        public virtual ICollection<ItemSizes> ItemSizes { get; set; }
    }
}
