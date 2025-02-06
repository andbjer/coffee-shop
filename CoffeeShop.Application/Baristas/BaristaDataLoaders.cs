using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Entities;
using GreenDonut;

namespace CoffeeShop.Application.Baristas;

public static class BaristaDataLoaders
{
    [DataLoader]
    public static async Task<Dictionary<Guid, Barista>> GetBaristaByIdAsync(
        IReadOnlyList<Guid> baristaIds,
        ICoffeeShopDbContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Baristas.AsNoTracking()
            .Where(x => baristaIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}
