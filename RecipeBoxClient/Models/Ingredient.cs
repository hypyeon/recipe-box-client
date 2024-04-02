using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBoxClient.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public List<RecipeIngredient> RecipeIngredients { get; set; }
  }
}
