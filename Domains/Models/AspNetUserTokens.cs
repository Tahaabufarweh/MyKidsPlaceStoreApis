using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class AspNetUserTokens : IdentityUserToken<long>
    {
        public long UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
