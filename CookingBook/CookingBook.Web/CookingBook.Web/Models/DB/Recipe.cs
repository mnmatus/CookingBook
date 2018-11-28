using System;
using System.Collections.Generic;

namespace CookingBook.Web.Models.DB
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Ingredient> Ingredient { get; set; }
    }
}
