using CoffeeShop.Application;
using CoffeeShop.Infrastructure;
using CoffeeShop.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();
builder.AddInfrastructureServices();
builder.AddGraphQL().AddApiTypes().AddApplicationTypes();

var app = builder.Build();

await app.Services.InitializeDatabaseAsync();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
