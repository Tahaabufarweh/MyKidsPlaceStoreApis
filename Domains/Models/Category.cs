using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class Category : BaseModel
    {
        public Category()
        {
            Item = new HashSet<Item>();
        }

        public string CategoryName { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public int SubCategoryId { get; set; }

        public virtual ApplicationUser CreatedByNavigation { get; set; }
        public virtual ApplicationUser ModifiedByNavigation { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
