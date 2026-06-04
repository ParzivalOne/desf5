using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Repositories;
using WebStore.Infrastructure.Repositories.Interfaces;
using WebStore.Services;
using WebStore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WebStoreDBContext>(options =>
{
    options.UseSqlite("Data Source=webStore.db");
});

builder.Services
    .AddTransient<IClienteRepository, ClienteRepository>()
    .AddTransient<IPedidoRepository, PedidoRepository>()
    .AddTransient<IProdutoRepository, ProdutoRepository>()
    .AddTransient<IClienteService, ClienteService>()
    .AddTransient<IPedidoService, PedidoService>()
    .AddTransient<IProdutoService, ProdutoService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
