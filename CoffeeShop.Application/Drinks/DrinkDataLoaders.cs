using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Entities;
using GreenDonut;

namespace CoffeeShop.Application.Drinks;

public static class DrinkDataLoaders
{
    [DataLoader]
    public static async Task<Dictionary<Guid, Drink>> GetDrinkByIdAsync(
        IReadOnlyList<Guid> drinkIds,
        ICoffeeShopDbContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Drinks.AsNoTracking()
            .Where(x => drinkIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}
