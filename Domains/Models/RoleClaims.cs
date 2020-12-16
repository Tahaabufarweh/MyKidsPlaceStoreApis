using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class RoleClaims : IdentityRoleClaim<long>
    {
        public int Id { get; set; }
        public long RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Roles Role { get; set; }
    }
}
