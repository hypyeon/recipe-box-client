using System.Threading.Tasks;
using RestSharp;

namespace RecipeBoxClient.Models
{
  public class ApiHelper
  {
    // Recipes
    public static async Task<string> GetRecipes()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    public static async Task<string> GetRecipeDetail(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    public static async void PostRecipe(string newRecipe)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newRecipe);
      await client.PostAsync(request);
    }
    public static async void PostAddIngredient(int recipeId, int ingId)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes/{recipeId}/AddIngredient", Method.Post);
      request.AddHeader("Content-Type", "application/json;data=verbose");
      request.AddJsonBody(new { recipeId, ingId });
      await client.PostAsync(request);
    }
    public static async void PutRecipe(int id, string newRecipe)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newRecipe);
      await client.PutAsync(request);
    }
    public static async void DeleteRecipe(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }

    // Categories
    public static async Task<string> GetCategories()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/categories", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    public static async Task<string> GetCategoryDetail(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/categories/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    // Ingredients 
    public static async Task<string> GetIngredients()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/ingredients", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    public static async Task<string> GetIngredientDetail(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/ingredients/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    public static async void PostIngredient(string newIng)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/ingredients", Method.Post);
      request.AddHeader("Content-Type", "application/json;data=verbose");
      request.AddJsonBody(newIng);
      await client.PostAsync(request);
    }
    public static async void PutIngredient(int id, string newIng)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/ingredients/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newIng);
      await client.PutAsync(request);
    }
    public static async void DeleteIngredient(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/ingredients/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}