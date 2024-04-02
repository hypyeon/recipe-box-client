using System.Collections.Generic;

namespace RecipeBoxClient.Models
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Recipe> Recipes { get; set; }
  }
}