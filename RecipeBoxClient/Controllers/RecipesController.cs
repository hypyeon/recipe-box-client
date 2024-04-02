using Microsoft.AspNetCore.Mvc;
using RecipeBoxClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading;

namespace RecipeBoxClient.Controllers;

public class RecipesController : Controller
{
  public IActionResult Index()
  {
    List<Recipe> recipes = Recipe.GetAll();
    return View(recipes);
  }
  public IActionResult Details(int id)
  {
    Recipe recipe = Recipe.GetDetail(id);
    return View(recipe);
  }
  public ActionResult Create()
  {
    //List<Ingredient> ing = Ingredient.GetAll();
    //ViewBag.IngredientId = new SelectList(ing, "IngredientId", "Name");
    return View();
  }
  [HttpPost]
  public ActionResult Create(Recipe recipe)
  {
    Recipe.Post(recipe);
    return RedirectToAction("Details", new { id = recipe.RecipeId });
  }
  public ActionResult Edit(int id)
  {
    Recipe recipe = Recipe.GetDetail(id);
    return View(recipe);
  }
  [HttpPost]
  public ActionResult Edit(Recipe recipe)
  {
    Recipe.Put(recipe);
    return RedirectToAction("Details", new { id = recipe.RecipeId});
  }

  public ActionResult Delete(int id)
  {
    Recipe recipe = Recipe.GetDetail(id);
    return View(recipe);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Recipe.Delete(id);
    return RedirectToAction("Index");
  }
}