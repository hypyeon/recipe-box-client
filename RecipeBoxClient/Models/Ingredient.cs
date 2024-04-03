using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RecipeBoxClient.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public List<RecipeIngredient> RecipeIngredients { get; set; }

    public static List<Ingredient> GetAll()
    {
      var apiCallTask = ApiHelper.GetIngredients();
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Ingredient> ingredientList = JsonConvert.DeserializeObject<List<Ingredient>>(jsonResponse.ToString());

      return ingredientList;
    }
    public static Ingredient GetDetail(int id)
    {
      var apiCallTask = ApiHelper.GetIngredientDetail(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Ingredient ing = JsonConvert.DeserializeObject<Ingredient>(jsonResponse.ToString());

      return ing;
    }
    public static void Post(Ingredient ing)
    {
      string jsonRecipe = JsonConvert.SerializeObject(ing);
      ApiHelper.PostIngredient(jsonRecipe);
    }
    public static void Put(Ingredient ing)
    {
      string jsonRecipe = JsonConvert.SerializeObject(ing);
      ApiHelper.PutIngredient(ing.IngredientId, jsonRecipe);
    }
    public static void Delete(int id)
    {
      ApiHelper.DeleteIngredient(id);
    }
  }
}
