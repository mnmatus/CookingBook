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
    [Authorize]
    [Route("api/ingredient")]
    [ApiController]
    public class IngredientController : BaseController
    {
        private readonly CookingBookContext _context;
        private IConfiguration _config;
        private IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        private IUserRepository _userRepository;
        public IngredientController(IConfiguration config, CookingBookContext context, IIngredientRepository ingredientRepository, IMapper mapper, IUserRepository userRepository) : base(userRepository)
        {
            _context = context;
            _config = config;
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }


        [HttpPost("updateingredient")]
        public IActionResult UpdateIngredient(IngredientDto request)
        {
            var recipe = _ingredientRepository.UpdateIngredient(request);            
            return Ok();
        }


    }
}