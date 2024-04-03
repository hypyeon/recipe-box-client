using Microsoft.AspNetCore.Mvc;
using RecipeBoxClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading;

namespace RecipeBoxClient.Controllers;

public class CategoriesController : Controller
{
  public IActionResult Index()
  {
    List<Category> cats = Category.GetAll();
    return View(cats);
  }
  public IActionResult Details(int id)
  {
    Category cat = Category.GetDetail(id);
    return View(cat);
  }
}