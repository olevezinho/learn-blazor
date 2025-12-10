using BlazorClientesNet10.Components;
using BlazorClientesNet10.Context;
using BlazorClientesNet10.Repositories;
using BlazorClientesNet10.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

// Adicionar o serviço do entity framework
builder.Services.AddDbContext<ClienteContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!)
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorClientesNet10.Client._Imports).Assembly);

app.Run();
