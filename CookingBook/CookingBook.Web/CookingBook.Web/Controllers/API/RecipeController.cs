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
    [Route("api/recipe")]
    [ApiController]
    public class RecipeController : BaseController
    {        
        private IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private IUserRepository _userRepository;
        public RecipeController(IRecipeRepository recipeRepository, IMapper mapper, IUserRepository userRepository) : base(userRepository)
        {     
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        
        [HttpGet("getrecipesbyuser")]
        public IActionResult GetRecipesByUser()
        {
            var activeUser = ActiveUser;
            var recipes = _recipeRepository.GetRecipesByUser(activeUser.Id);
            List<RecipeDto> response = new List<RecipeDto>();
            foreach (var recipe in recipes)
            {
                var recipeDto = _mapper.Map<RecipeDto>(recipe);
                response.Add(recipeDto);
            }
            return Ok(response);
        }

        [HttpGet("getrecipesbyname/{name}")]
        [HttpGet("getrecipesbyname/")]
        public IActionResult GetRecipesByName(string name = "")
        {
            var activeUser = ActiveUser;
            var recipes = _recipeRepository.GetRecipesByName(activeUser.Id,name);
            List<RecipeDto> response = new List<RecipeDto>();
            foreach (var recipe in recipes)
            {               
                var recipeDto = _mapper.Map<RecipeDto>(recipe);
                response.Add(recipeDto);
            }
            return Ok(response);
        }        
        
        [HttpPost("addnewrecipe")]
        public IActionResult AddNewRecipe(RecipeDto request)
        {
            var activeUser = ActiveUser;
            request.UserId = activeUser.Id;
            var id = _recipeRepository.AddNewRecipe(request);            
            return Ok();
        }

        [HttpPost("updaterecipe")]
        public IActionResult UpdateRecipe(RecipeDto request)
        {            
            var id = _recipeRepository.UpdateRecipe(request);
            return Ok();
        }


        [HttpGet("getrecipebyid/{id}")]
        public IActionResult GetRecipeById(int id)
        {            
            var recipe = _recipeRepository.GetRecipeById(id);
            var recipeDto = _mapper.Map<RecipeDto>(recipe);
            return Ok(recipeDto);
        }

    }
}