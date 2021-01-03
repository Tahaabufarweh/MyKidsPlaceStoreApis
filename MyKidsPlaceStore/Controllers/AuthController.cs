using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domains.DTO;
using Domains.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.UnitOfWork;

namespace MyKidsPlaceStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public AuthController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
     
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                TokenResponseDTO tokenResponseDTO = await _serviceUnitOfWork.Auth.Value.Login(loginDTO, true);
                return Ok(tokenResponseDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSignup([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                ApplicationUser applicationUser = await _serviceUnitOfWork.Auth.Value.Create(registerDTO);
                return Ok(applicationUser);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRegId(string regId)
        {
            try
            {
                ApplicationUser applicationUser = await _serviceUnitOfWork.Auth.Value.UpdateRegId(regId);
                return Ok(applicationUser);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}