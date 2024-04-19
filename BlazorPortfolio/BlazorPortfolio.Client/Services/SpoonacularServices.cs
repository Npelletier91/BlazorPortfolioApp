using BlazorPorfolio.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;



namespace BlazorPortfolio.Client.Services
{
    public class SpoonacularServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public SpoonacularServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["SpoonacularApiKey"];
        }
        public async Task<RecipeData> GetRecipeAsync()
        {

            string requestUri = $"https://api.spoonacular.com/recipes/random?apiKey={_apiKey}&number=1";

            HttpResponseMessage responce = await _httpClient.GetAsync(requestUri);

            if (responce.IsSuccessStatusCode)
            {
                string jsonResponse = await responce.Content.ReadAsStringAsync();
                var recipeData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                if (recipeData.recipes.Count > 0)
                {
                    return new RecipeData
                    {
                        Title = recipeData.recipes[0].title,
                        Image = recipeData.recipes[0].image,
                        SourceUrl = recipeData.recipes[0].sourceUrl,
                        ReadyInMinutes = recipeData.recipes[0].readyInMinutes
                    };
                }
            }

            return null;
        }
    }
}
