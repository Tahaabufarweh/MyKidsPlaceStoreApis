using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class MasterCategory : BaseModel
    {
        public MasterCategory()
        {
            Category = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}
