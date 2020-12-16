using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class MasterCategory : BaseModel
    {
        public MasterCategory()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public string CategoryName { get; set; }
        public int Status { get; set; }

        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
