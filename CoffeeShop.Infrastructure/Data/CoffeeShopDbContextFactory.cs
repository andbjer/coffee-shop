using CoffeeShop.Application.Common;

namespace CoffeeShop.Infrastructure.Data;

public class CoffeeShopDbContextFactory(IDbContextFactory<CoffeeShopDbContext> dbContextFactory)
    : ICoffeeShopDbContextFactory
{
    public async Task<ICoffeeShopDbContext> CreateDbContextAsync(
        CancellationToken cancellationToken
    )
    {
        return await dbContextFactory.CreateDbContextAsync(cancellationToken);
    }
}
