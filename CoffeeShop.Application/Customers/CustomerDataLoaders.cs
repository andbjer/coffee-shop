using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Entities;
using GreenDonut;

namespace CoffeeShop.Application.Customers;

public static class CustomerDataLoaders
{
    [DataLoader]
    public static async Task<Dictionary<Guid, Customer>> GetCustomerByIdAsync(
        IReadOnlyList<Guid> customerIds,
        ICoffeeShopDbContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Customers.AsNoTracking()
            .Where(x => customerIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}
