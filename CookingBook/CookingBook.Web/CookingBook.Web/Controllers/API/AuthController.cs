using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CookingBook.Application.IRepository;


using Microsoft.AspNetCore.Authorization;
using CookingBook.Dto.Request;


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CookingBook.Dto.Entity;
using CookingBook.Application.Helpers;

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
            // var currentUser = ActiveUser;
            //return Ok(currentUser);

            var identity = User.Identity as ClaimsIdentity;
            var userId = identity == null ? null : identity.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userId == null)
                return Ok("");
            return Ok("Meron");
            //var persona = Persona;
            //if (persona.ActiveUser == null)
            //    return Ok("");

            //var user = _userRepository.GetUserById(Guid.Parse(userId.Value));
            //var userName = user.UserName;


            //return Ok(userName);
        }
    }
}