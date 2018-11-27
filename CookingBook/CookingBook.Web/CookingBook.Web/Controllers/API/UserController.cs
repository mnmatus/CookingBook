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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {        
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;            
        }


        [HttpGet]
        [Route("getuserbyid/{id}")]
        public ActionResult GetUserById()
        {
            var user = _userRepository.GetUserById(1);            
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginRequestDto request)
        {
            var user = _userRepository.GetUserByUserName(request.UserName);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TheSecretKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            UserDto userDto = new UserDto();
            userDto.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;
            return Ok(userDto);
        }
    }
}