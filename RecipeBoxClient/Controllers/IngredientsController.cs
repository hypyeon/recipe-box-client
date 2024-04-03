using Microsoft.AspNetCore.Mvc;
using RecipeBoxClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading;

namespace RecipeBoxClient.Controllers;

public class IngredientsController : Controller
{
  public IActionResult Index()
  {
    List<Ingredient> ins = Ingredient.GetAll();
    return View(ins);
  }
  public IActionResult Details(int id)
  {
    Ingredient ing = Ingredient.GetDetail(id);
    return View(ing);
  }
  public ActionResult Create()
  {
    return View();
  }
  [HttpPost]
  public ActionResult Create(Ingredient ing)
  {
    Ingredient.Post(ing);
    return RedirectToAction("Index");
  }
  public ActionResult Edit(int id)
  {
    Ingredient ing = Ingredient.GetDetail(id);
    return View(ing);
  }
  [HttpPost]
  public ActionResult Edit(Ingredient ing)
  {
    Ingredient.Put(ing);
    return RedirectToAction("Details", new { id = ing.IngredientId});
  }

  public ActionResult Delete(int id)
  {
    Ingredient ing = Ingredient.GetDetail(id);
    return View(ing);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Ingredient.Delete(id);
    return RedirectToAction("Index");
  }
}