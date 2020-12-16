using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class SubCategory : BaseModel
    {
        public SubCategory()
        {
            Category = new HashSet<Category>();
        }

        public string SubCategoryName { get; set; }
        public int Status { get; set; }
        public int MasterCategoryId { get; set; }

        public virtual MasterCategory MasterCategory { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
