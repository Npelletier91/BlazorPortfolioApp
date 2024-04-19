using Blazored.LocalStorage;
using BlazorPortfolio.Client;
using BlazorPortfolio.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;




var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient<SpoonacularServices>(client =>
{
    client.BaseAddress = new Uri("https://api.spoonacular.com/");
}).ConfigureHttpClient((serviceProvider, client) =>
{
    var config = serviceProvider.GetRequiredService<IConfiguration>();
    client.DefaultRequestHeaders.Add("X-Api-Key", config["SpoonacularApiKey"]);
});

await builder.Build().RunAsync();
