using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookingBook.Web.Models.DB;
using CookingBook.Web.Dto.Entity;

namespace CookingBook.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, RecipeDto>().ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredient));
           // CreateMap<UserDto, User>();
        }
    }
}
