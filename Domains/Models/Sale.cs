using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class Sale: BaseModel
    {
        public int ItemId { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Item Item { get; set; }
    }
}
