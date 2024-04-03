using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RecipeBoxClient.Models
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Recipe> Recipes { get; set; }

    public static List<Category> GetAll()
    {
      var apiCallTask = ApiHelper.GetCategories();
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Category> catList = JsonConvert.DeserializeObject<List<Category>>(jsonResponse.ToString());

      return catList;
    }
    public static Category GetDetail(int id)
    {
      var apiCallTask = ApiHelper.GetCategoryDetail(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Category cat = JsonConvert.DeserializeObject<Category>(jsonResponse.ToString());

      return cat;
    }
  }
}