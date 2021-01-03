using Domains.Common;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class Colour : BaseModel
    {
        public Colour()
        {
            ItemColors = new HashSet<ItemColors>();
        }

        public string Color { get; set; }

        public virtual ICollection<ItemColors> ItemColors { get; set; }
    }
}
