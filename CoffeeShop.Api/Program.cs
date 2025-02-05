using CoffeeShop.Infrastructure;
using CoffeeShop.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();
builder.AddGraphQL().AddTypes();

var app = builder.Build();

await app.Services.InitializeDatabaseAsync();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
