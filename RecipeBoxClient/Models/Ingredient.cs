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
  }
}
