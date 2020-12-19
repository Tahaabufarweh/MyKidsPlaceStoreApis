using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class Category : BaseModel
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public int MasterCategoryId { get; set; }

        public virtual MasterCategory MasterCategory { get; set; }
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
