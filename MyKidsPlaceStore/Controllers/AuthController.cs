using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyKidsPlaceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        

        public AuthController(
           
            )
        {
            
        }

        public IActionResult Login()
        {
            
            return Ok();
        }

        public IActionResult RegisterSignup()
        {
            return Ok();
        }

    }
}