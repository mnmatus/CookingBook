using System;
using System.Collections.Generic;

namespace CookingBook.Web.Models.DB
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsChecked { get; set; }
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
