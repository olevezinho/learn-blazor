using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorShop.Web;
using BlazorShop.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "http://localhost:5268";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IGereCarrinhoItensLocalStorageService, GereCarrinhoItensLocalStorageService>();
builder.Services.AddScoped<IGereProdutosLocalStorageService, GereProdutosLocalStorageService>();

await builder.Build().RunAsync();