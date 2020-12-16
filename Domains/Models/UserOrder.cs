using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class UserOrder : BaseModel
    {
        public int ItemId { get; set; }
        public long UserId { get; set; }
        public int OrderCount { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }

        public virtual ApplicationUser CreatedByNavigation { get; set; }
        public virtual Item Item { get; set; }
        public virtual ApplicationUser ModifiedByNavigation { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
