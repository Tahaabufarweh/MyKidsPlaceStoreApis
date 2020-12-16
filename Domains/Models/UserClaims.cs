using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class UserClaims : IdentityUserClaim<long>
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
