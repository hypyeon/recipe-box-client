using System.Threading.Tasks;
using RestSharp;

namespace RecipeBoxClient.Models
{
  public class ApiHelper
  {
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
    public static async void Post(string newRecipe)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newRecipe);
      await client.PostAsync(request);
    }
    public static async void Put(int id, string newRecipe)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newRecipe);
      await client.PutAsync(request);
    }
    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/recipes/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }

    public static async Task<string> GetIngredients()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/ingredients", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetCategories()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/categories", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
  }
}