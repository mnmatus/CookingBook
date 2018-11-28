using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingBook.Web.Models.DB;
using CookingBook.Web.Dto.Entity;

namespace CookingBook.Web.IRepository
{
    public interface IRecipeRepository
    {
        Recipe GetRecipeById(int id);
        IQueryable<Recipe> GetRecipesByName(int userId, string name);

        IQueryable<Recipe> GetRecipesByUser(int id);

        int AddNewRecipe(RecipeDto recipe);

        int UpdateRecipe(RecipeDto recipe);
        
    }
}
