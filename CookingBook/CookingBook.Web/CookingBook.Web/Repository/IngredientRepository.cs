using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingBook.Web.IRepository;
using CookingBook.Web.Models.DB;
using CookingBook.Web.Dto.Entity;
using Microsoft.EntityFrameworkCore;


namespace CookingBook.Web.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly CookingBookContext _context;
        public IngredientRepository(CookingBookContext context)
        {
            _context = context;
        }
        public bool UpdateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _context.Ingredient.FirstOrDefault(i => i.Id == ingredientDto.Id);
            ingredient.IsChecked = ingredientDto.IsChecked;
            _context.SaveChanges();
            return true;
        }

        public bool ResetIngredientSelection(int id)
        {
            var ingredients = _context.Ingredient.Where(i => i.RecipeId == id);
            foreach (var ingredient in ingredients)
                ingredient.IsChecked = false;            
            _context.SaveChanges();            
            return true;
        }
    }
}
