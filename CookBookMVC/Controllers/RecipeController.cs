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
            List<IngredientModel> ing = new List<IngredientModel>
            {
                new IngredientModel() {Name="Pietruszka" },
                new IngredientModel() { Name = "Seler" },
                new IngredientModel() { Name = "Mięso" }
            };

            RecipeModel recipeModel = new RecipeModel()
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
        public IActionResult Create(RecipeModel recipeModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(recipeModel);
        }
    }
}
