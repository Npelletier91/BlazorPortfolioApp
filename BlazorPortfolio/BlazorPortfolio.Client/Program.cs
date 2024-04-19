using Blazored.LocalStorage;
using BlazorPortfolio.Client;
using BlazorPortfolio.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;



var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient<SpoonacularServices>(client =>
{
    client.BaseAddress = new Uri("https://api.spoonacular.com/");
});

await builder.Build().RunAsync();
