using CoffeeShop.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Orders;

[QueryType]
public static class OrderQueries
{
    public static IQueryable<Order> GetOrders(ICoffeeShopDbContext context)
    {
        return context.Orders.AsNoTracking().OrderBy(x => x.Created);
    }
}
