using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CookingBook.Web.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CookingBook.Web.Dto;


namespace CookingBook.Web.Controllers.API
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("validate")]
        public IActionResult Validate()
        {
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
                return Ok("Valid");
            else
                return Ok("");            
        }

        [Authorize]
        [HttpPost]
        [Route("validate2")]
        public IActionResult Validate2()
        {
            return Ok();
        }
    }
}