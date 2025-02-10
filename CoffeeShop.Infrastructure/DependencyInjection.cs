using CoffeeShop.Application.Common;
using CoffeeShop.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoffeeShop.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("CoffeeShopDb");

        builder.Services.AddDbContext<CoffeeShopDbContext>(
            options =>
            {
                options.UseSqlServer(connectionString);
            },
            optionsLifetime: ServiceLifetime.Singleton
        );
        builder.Services.AddPooledDbContextFactory<CoffeeShopDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddScoped<ICoffeeShopDbContext>(provider =>
            provider.GetRequiredService<CoffeeShopDbContext>()
        );
        builder.Services.AddScoped<ICoffeeShopDbContextFactory, CoffeeShopDbContextFactory>();

        builder.Services.AddScoped<CoffeeShopDbInitializer>();
    }
}
