using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class Roles : IdentityRole<long>
    {
        public Roles()
        {
            RoleClaims = new HashSet<RoleClaims>();
            UserRoles = new HashSet<UserRoles>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<RoleClaims> RoleClaims { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
