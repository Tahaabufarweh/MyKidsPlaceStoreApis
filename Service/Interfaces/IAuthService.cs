using Domains.DTO;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthService
    {
         Task<TokenResponseDTO> Login(LoginDTO model, bool isMobile);
         Task<ApplicationUser> Create(RegisterDTO model);
         Task<ApplicationUser> UpdateRegId(string regId);

    }
}
