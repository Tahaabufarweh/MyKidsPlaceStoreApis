using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domains.Models
{
    public partial class UserLogins : IdentityUserLogin<long>
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public long UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
