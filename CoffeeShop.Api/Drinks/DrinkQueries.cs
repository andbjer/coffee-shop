using CoffeeShop.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Drinks;

[QueryType]
public static class DrinkQueries
{
    public static IQueryable<Drink> GetDrinks(ICoffeeShopDbContext context)
    {
        return context.Drinks.AsNoTracking().OrderBy(x => x.Name);
    }
}
