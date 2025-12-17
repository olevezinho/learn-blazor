using BlazorQuickGridEF.Components;
using BlazorQuickGridEF.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("Sqlite");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

// Adicionar o serviço do quickgrid
builder.Services.AddQuickGridEntityFrameworkAdapter();

var app = builder.Build();

CreateDatabaseIfNotExists(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    .AddInteractiveServerRenderMode();

app.Run();

static void CreateDatabaseIfNotExists(WebApplication webApplication)
{
    var serviceScope = webApplication.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.EnsureCreated();
}