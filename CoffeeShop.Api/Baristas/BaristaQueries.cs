using CoffeeShop.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Baristas;

[QueryType]
public static class BaristaQueries
{
    public static IQueryable<Barista> GetBaristas(ICoffeeShopDbContext context)
    {
        return context.Baristas.AsNoTracking().OrderBy(x => x.Name);
    }
}
