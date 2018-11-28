using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingBook.Web.Dto.Entity
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}
