using BlazorShop.API.Context;
using BlazorShop.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi("v1",options =>
{
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.DotNetFlag = true;
        options.Title = "Blazor Shop API";
    });
    
    app.UseCors(policy => policy
        .WithOrigins("http://localhost:5251")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();