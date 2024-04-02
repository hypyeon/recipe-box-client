using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RecipeBoxClient.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    public string Title { get; set; }
    public string Instruction { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<RecipeIngredient> RecipeIngredients { get; set; }

    public static List<Recipe> GetAll()
    {
      var apiCallTask = ApiHelper.GetAllRecipes();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Recipe> recipeList = JsonConvert.DeserializeObject<List<Recipe>>(jsonResponse.ToString());

      return recipeList;
    }
    public static Recipe GetDetail(int id)
    {
      var apiCallTask = ApiHelper.GetRecipeDetail(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Recipe recipe = JsonConvert.DeserializeObject<Recipe>(jsonResponse.ToString());

      return recipe;
    }
    public static void Post(Recipe recipe)
    {
      string jsonRecipe = JsonConvert.SerializeObject(recipe);
      ApiHelper.Post(jsonRecipe);
    }
    public static void Put(Recipe recipe)
    {
      string jsonRecipe = JsonConvert.SerializeObject(recipe);
      ApiHelper.Put(recipe.RecipeId, jsonRecipe);
    }
    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}