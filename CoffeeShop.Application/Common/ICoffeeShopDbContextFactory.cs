namespace CoffeeShop.Application.Common;

public interface ICoffeeShopDbContextFactory
{
    Task<ICoffeeShopDbContext> CreateDbContextAsync(CancellationToken cancellationToken);
}
