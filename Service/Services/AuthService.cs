using Domains.Common;
using Domains.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        AppConfiguration _appConfiguration = new AppConfiguration();
        public AuthService(
             UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private async Task<IList<Claim>> BuildClaims(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                 new Claim(ClaimTypes.Email, user.Email),
            };
            foreach (var item in roles)
            {
                var roleclaim = new Claim(ClaimTypes.Role, item);
                claims.Add(roleclaim);
            }


            return claims;
        }

        //change this please
        private object buildUserLoginObject(ApplicationUser user, IList<Claim> claims, IList<string> roles)
        {
            var response = new {
                access_token = WriteToken(claims),
            UserId = user.Id.ToString(),
            phoneNumber = user.PhoneNumber,
            fullName = user.FullName,
            email = user.Email,
            roles = roles,
         };
           
            return response;
        }
        private string WriteToken(IList<Claim> claims)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration.Issuer));

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                    issuer: _appConfiguration.Issuer,
                    audience: _appConfiguration.Audience,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddYears(100),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        public async Task ChangePasswordAsync(long UserId, string NewPassword)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == UserId);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, NewPassword);
        }
    }
}
