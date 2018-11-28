using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingBook.Web.Models.DB;
using CookingBook.Web.Dto.Entity;

namespace CookingBook.Web.IRepository
{
    public interface IIngredientRepository
    {        
        bool UpdateIngredient(IngredientDto ingredient);

        bool ResetIngredientSelection(int id);
    }
}
