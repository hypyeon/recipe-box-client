namespace RecipeBoxClient.Models
{
  public class Favorite
  {
    public int FavoriteId { get; set; }
    public bool IsFavorite { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public string UserId { get; set; } 
    public ApplicationUser User { get; set; } 
  }
}
