using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CookingBook.Web.IRepository;
using CookingBook.Web.Repository;
using Microsoft.AspNetCore.Authorization;


using CookingBook.Web.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using CookingBook.Web.Models;
using CookingBook.Web.Models.DB;
using AutoMapper;
using CookingBook.Web.Dto.Entity;

namespace CookingBook.Web.Controllers.API
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {        
        private IConfiguration _config;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IConfiguration config, IMapper mapper, CookingBookContext context, IUserRepository userRepository) : base(userRepository)
        {            
            _config = config;
            _mapper = mapper;
            _userRepository = userRepository;
        }


        [Authorize]
        [HttpGet("getactiveuser")]
        public IActionResult GetActiveUser()
        {
            var activeUser = ActiveUser;
            var userDto = _mapper.Map<UserDto>(activeUser);
            return Ok(userDto);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginRequestDto request)
        {
            IActionResult response = NotFound();
            var user = _userRepository.GetUserByCredential(request.UserName, request.Password);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }          

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var key = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Name, userInfo.Guid.ToString()),        
            };

            var issuer = _config["Jwt:Issuer"];
            var token = new JwtSecurityToken(issuer,
       _config["Jwt:Issuer"],
       claims,
       expires: DateTime.Now.AddMinutes(120),
       signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       
    }
}