using BlazorPorfolio.Models;
using Newtonsoft.Json;



namespace BlazorPortfolio.Client.Services
{
    public class SpoonacularServices
    {
        private readonly HttpClient _httpClient;
        private string apiKey = "c9f33c53612f4c0d8015b22be380b457";

        public SpoonacularServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<RecipeData> GetRecipeAsync()
        {

            string requestUri = $"https://api.spoonacular.com/recipes/random?apiKey={apiKey}&number=1";

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
