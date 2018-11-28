using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingBook.Web.IRepository;
using CookingBook.Web.Models.DB;
using CookingBook.Web.Dto.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace CookingBook.Web.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CookingBookContext _context;
        public RecipeRepository(CookingBookContext context)
        {
            _context = context;
        }
        public IQueryable<Recipe> GetRecipesByName(int userId, string name)
        {
            var recipes = _context.Recipe.Where(r => r.Name.StartsWith(name) && r.UserId == userId);
            return recipes;
        }

        public IQueryable<Recipe> GetRecipesByUser(int id)
        {
            var recipes = _context.Recipe.Where(r => r.UserId == id);
            return recipes;
        }

        public int AddNewRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = new Recipe {
                Name = recipeDto.Name,
                UserId = recipeDto.UserId,
            };
            foreach(var ing in recipeDto.Ingredients)
            {
                Ingredient ingredient = new Ingredient {
                    Name = ing.Name,
                };
                recipe.Ingredient.Add(ingredient);
            }
            _context.Recipe.Add(recipe);
            _context.SaveChanges();
            return recipe.Id;
        }

        public int UpdateRecipe(RecipeDto recipeDto)
        {
            var recipe = _context.Recipe.Include(r => r.Ingredient).FirstOrDefault(r=> r.Id == recipeDto.Id);
            recipe.Name = recipeDto.Name;

            var oldIngredients = (from item in recipe.Ingredient select item);
            _context.Ingredient.RemoveRange(oldIngredients);
            _context.SaveChanges();
            foreach (var ing in recipeDto.Ingredients)
            {
                Ingredient ingredient = new Ingredient
                {
                    Name = ing.Name,
                };
                recipe.Ingredient.Add(ingredient);
            }

            _context.SaveChanges();
            return recipe.Id;
        }

        public Recipe GetRecipeById(int id)
        {
            var recipe = _context.Recipe.Include(r => r.Ingredient).FirstOrDefault(r => r.Id == id);
            return recipe;
        }
    }
}
