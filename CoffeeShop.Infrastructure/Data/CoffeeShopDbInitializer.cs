using CoffeeShop.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Infrastructure.Data;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<CoffeeShopDbInitializer>();

        await initializer.InitializeAsync();
        await initializer.SeedAsync();
    }
}

public class CoffeeShopDbInitializer(
    CoffeeShopDbContext context,
    ILogger<CoffeeShopDbContext> logger
)
{
    public async Task InitializeAsync()
    {
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await SeedBaristasAsync();
            await SeedDrinksAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occured while seeding the database.");
        }
    }

    private async Task SeedBaristasAsync()
    {
        if (context.Baristas.Any())
        {
            return;
        }

        var baristas = new List<Barista>
        {
            new() { Name = "Bean Diesel" },
            new() { Name = "Cappuccino Carl" },
            new() { Name = "Latte Larry" },
            new() { Name = "Mocha Joe" },
            new() { Name = "Brewce Wayne" },
            new() { Name = "Charlie Chai" },
        };

        context.Baristas.AddRange(baristas);
        await context.SaveChangesAsync();
    }

    private async Task SeedDrinksAsync()
    {
        if (context.Drinks.Any())
        {
            return;
        }

        var drinks = new List<Drink>
        {
            new()
            {
                Name = "Espresso Shot",
                Description = "Pure, concentrated coffee bliss.",
                Price = 2.50,
                CaffeineLevel = CaffeineLevel.High,
                PreparationTime = TimeSpan.FromMinutes(0.5),
            },
            new()
            {
                Name = "Cappuccino",
                Description = "A creamy blend of espresso and steamed milk foam.",
                Price = 3.50,
                CaffeineLevel = CaffeineLevel.Medium,
                PreparationTime = TimeSpan.FromMinutes(3),
            },
            new()
            {
                Name = "Flat White",
                Description = "Smooth, velvety espresso and microfoam.",
                Price = 3.75,
                CaffeineLevel = CaffeineLevel.Medium,
                PreparationTime = TimeSpan.FromMinutes(2),
            },
            new()
            {
                Name = "Americano",
                Description = "Espresso diluted with hot water.",
                Price = 2.75,
                CaffeineLevel = CaffeineLevel.High,
                PreparationTime = TimeSpan.FromMinutes(1.5),
            },
            new()
            {
                Name = "Mocha Madness",
                Description = "Espresso, chocolate syrup, and milk.",
                Price = 4.25,
                CaffeineLevel = CaffeineLevel.High,
                PreparationTime = TimeSpan.FromMinutes(2),
            },
            new()
            {
                Name = "Chai Latte",
                Description = "Spiced black tea with steamed milk.",
                Price = 3.50,
                CaffeineLevel = CaffeineLevel.Low,
                PreparationTime = TimeSpan.FromMinutes(3),
            },
            new()
            {
                Name = "Matcha Green Tea Latte",
                Description = "Steamed milk mixed with matcha powder.",
                Price = 4.00,
                CaffeineLevel = CaffeineLevel.Low,
                PreparationTime = TimeSpan.FromMinutes(3),
            },
            new()
            {
                Name = "Vanilla Iced Coffee",
                Description = "Iced coffee with a hint of vanilla syrup.",
                Price = 3.25,
                CaffeineLevel = CaffeineLevel.Medium,
                PreparationTime = TimeSpan.FromMinutes(2),
            },
            new()
            {
                Name = "Caramel Macchiato",
                Description = "Espresso layered with vanilla and caramel drizzle.",
                Price = 4.50,
                CaffeineLevel = CaffeineLevel.Medium,
                PreparationTime = TimeSpan.FromMinutes(3),
            },
            new()
            {
                Name = "Cold Brew",
                Description = "Strong, smooth coffee brewed cold.",
                Price = 4.00,
                CaffeineLevel = CaffeineLevel.Extreme,
                PreparationTime = TimeSpan.FromMinutes(1),
            },
            new()
            {
                Name = "Decaf Coffee",
                Description = "All the flavor, none of the buzz.",
                Price = 2.25,
                CaffeineLevel = CaffeineLevel.None,
                PreparationTime = TimeSpan.FromMinutes(1),
            },
            new()
            {
                Name = "Pumpkin Spice Latte",
                Description = "Seasonal delight with espresso, pumpkin, and spices.",
                Price = 4.75,
                CaffeineLevel = CaffeineLevel.Medium,
                PreparationTime = TimeSpan.FromMinutes(3),
            },
            new()
            {
                Name = "Hazelnut Hot Chocolate",
                Description = "Creamy hot cocoa with hazelnut syrup.",
                Price = 3.00,
                CaffeineLevel = CaffeineLevel.None,
                PreparationTime = TimeSpan.FromMinutes(2.5),
            },
            new()
            {
                Name = "Energy Shot Espresso",
                Description = "Triple espresso shot for the brave souls.",
                Price = 5.50,
                CaffeineLevel = CaffeineLevel.Extreme,
                PreparationTime = TimeSpan.FromMinutes(1),
            },
        };
        context.Drinks.AddRange(drinks);
        await context.SaveChangesAsync();
    }
}
