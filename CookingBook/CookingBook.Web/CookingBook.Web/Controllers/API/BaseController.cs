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
using CookingBook.Web.Models.DB;

namespace CookingBook.Web.Controllers.API
{
    public class BaseController : ControllerBase
    {
        private IUserRepository _userRepo;

        public BaseController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public User ActiveUser
        {
            get
            {
                var userId = User.Identity.Name;               
                User user = _userRepo.GetUserById(Guid.Parse(userId));
                return user;
            }
        }
    }
}
