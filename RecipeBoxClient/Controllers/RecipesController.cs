using Microsoft.AspNetCore.Mvc;
using RecipeBoxClient.Models;

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
    return View();
  }
  [HttpPost]
  public ActionResult Create(Recipe recipe)
  {
    Recipe.Post(recipe);
    return RedirectToAction("Index");
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