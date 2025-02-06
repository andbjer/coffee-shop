using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Entities;
using GreenDonut;

namespace CoffeeShop.Application.Orders;

public static class OrderDataLoaders
{
    [DataLoader]
    public static async Task<Dictionary<Guid, Order>> GetOrderByIdAsync(
        IReadOnlyList<Guid> orderIds,
        ICoffeeShopDbContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Orders.AsNoTracking()
            .Where(x => orderIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
    }

    [DataLoader]
    public static async Task<Dictionary<Guid, List<Order>>> GetOrdersByBaristaIdAsync(
        IReadOnlyList<Guid> baristaIds,
        ICoffeeShopDbContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Orders.AsNoTracking()
            .Where(o => o.BaristaId.HasValue && baristaIds.Contains(o.BaristaId.Value))
            .GroupBy(o => o.BaristaId!.Value)
            .ToDictionaryAsync(group => group.Key, group => group.ToList(), cancellationToken);
    }

    [DataLoader]
    public static async Task<Dictionary<Guid, List<Order>>> GetOrdersByCustomerIdAsync(
        IReadOnlyList<Guid> customerIds,
        ICoffeeShopDbContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Orders.AsNoTracking()
            .Where(o => customerIds.Contains(o.CustomerId))
            .GroupBy(o => o.CustomerId)
            .ToDictionaryAsync(group => group.Key, group => group.ToList(), cancellationToken);
    }

    [DataLoader]
    public static async Task<Dictionary<Guid, List<Order>>> GetOrdersByDrinkIdAsync(
        IReadOnlyList<Guid> drinkIds,
        ICoffeeShopDbContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Orders.AsNoTracking()
            .Where(o => drinkIds.Contains(o.DrinkId))
            .GroupBy(o => o.DrinkId)
            .ToDictionaryAsync(group => group.Key, group => group.ToList(), cancellationToken);
    }
}
