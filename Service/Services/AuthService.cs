﻿using Domains.Common;
using Domains.DTO;
using Domains.Enums;
using Domains.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly LoggedInUserService _loggedInUserService;
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        AppConfiguration _appConfiguration = new AppConfiguration();
        public AuthService(
             UserManager<ApplicationUser> userManager,
            
              IRepositoryUnitOfWork repositoryUnitOfWork,
            SignInManager<ApplicationUser> signInManager,
             LoggedInUserService loggedInUserService
            )
        {
           _loggedInUserService = loggedInUserService;
            _userManager = userManager;
            _repositoryUnitOfWork = repositoryUnitOfWork;

            _signInManager = signInManager;
        }

        public async Task<TokenResponseDTO> Login(LoginDTO model, bool isMobile)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (signInResult.Succeeded)
            {
                //Todo: ApplicationUser is not linked correctly with other entities. Fix this and filter user when mobile is true to bring drivers and clients only 
                ApplicationUser user = _userManager.Users.FirstOrDefault(r => r.UserName == model.Username);
                if (user == null)
                {
                    throw new Exception("اسم المستخدم او كلمة المرور خاطئة");
                }
                IList<string> roles = await _userManager.GetRolesAsync(user);
                IList<Claim> claims = await BuildClaims(user);
                TokenResponseDTO tokenResponse = BuildUserLoginObject(user, claims, roles);
                return tokenResponse;
            }
            else
            {
                throw new ValidationException("اسم المستخدم او كلمة المرور خاطئة");
            }
           
        }


        public async Task<ApplicationUser> Create(RegisterDTO model)
        {
            // var userId = _principalService.GetUserId();
            bool existMobileNumber = _userManager.Users.FirstOrDefault(x => x.MobileNumber == model.MobileNumber) == null ? false : true;
           
            if (existMobileNumber)
            {
                throw new ValidationException("Mobile number is used");
            }

            ApplicationUser user = new ApplicationUser
            {
                CreatedAt = DateTime.Now,
                // CreatedBy = userId,
                Email = model.Email,
                FullName = model.FullName,
                IsActive = true,
                MobileNumber = model.MobileNumber,
                UserName = model.MobileNumber,
                Address = model.Address
            };

            
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                CreateRoleIfNotExist("User", user.Id);
                CreateUserCart(user.Id);
                return user;
            }
            throw new ValidationException("Error");
        }

        public async Task<ApplicationUser> UpdateRegId(string regId)
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                user.RegId = regId;
                await _userManager.UpdateAsync(user);
                return user;
            }
            else
            {
                throw new ValidationException("User not found");
            }
        }


            private async Task<IList<Claim>> BuildClaims(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.MobilePhone, user.MobileNumber),
                new Claim(ClaimTypes.StreetAddress, user.Address)
            };
            foreach (var item in roles)
            {
                var roleclaim = new Claim(ClaimTypes.Role, item);
                claims.Add(roleclaim);
            }


            return claims;
        }

        private void CreateRoleIfNotExist(string roleName, long userId)
        {
            Roles role = _repositoryUnitOfWork.Roles.Value.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                Roles roleObj = new Roles
                {
                    Id = 0,
                    Name = roleName
                };

                role = _repositoryUnitOfWork.Roles.Value.Add(roleObj);
            }
            UserRoles userRole = new UserRoles
            {
                RoleId = role.Id,
                UserId = userId
            };
            userRole = _repositoryUnitOfWork.UserRole.Value.Add(userRole);
        }

        private void CreateUserCart(long userId)
        {
            UserCart cart = new UserCart
            {
                UserId = userId,
                Status = (int)GlobalStatusEnum.Active
            };
            _repositoryUnitOfWork.UserCart.Value.Add(cart);

        }

        
        //change this please
        private TokenResponseDTO BuildUserLoginObject(ApplicationUser user, IList<Claim> claims, IList<string> roles)
        {
            TokenResponseDTO response = new TokenResponseDTO {
             AccessToken = WriteToken(claims)
            };
           
            return response;
        }
        private string WriteToken(IList<Claim> claims)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration.JWTKey));

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
