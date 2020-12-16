using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class UserRoles : IdentityUserRole<long>
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
