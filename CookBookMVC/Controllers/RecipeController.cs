using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookBookMVC.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            List<Ingredient> ing = new List<Ingredient>
            {
                new Ingredient() {Name="Pietruszka" },
                new Ingredient() { Name = "Seler" },
                new Ingredient() { Name = "Mięso" }
            };

            Recipe recipeModel = new Recipe()
            {
                Id = "asd123asf32411",
                Description = "Test description",
                Ingredients = ing
            };
            return View(recipeModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Recipe recipeModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(recipeModel);
        }
    }
}
