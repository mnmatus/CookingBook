using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CookingBook.Web.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}