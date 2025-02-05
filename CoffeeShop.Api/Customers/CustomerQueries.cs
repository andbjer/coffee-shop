using CoffeeShop.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Customers;

[QueryType]
public static class CustomerQueries
{
    public static IQueryable<Customer> GetCustomers(ICoffeeShopDbContext context)
    {
        return context.Customers.AsNoTracking().OrderBy(x => x.Name);
    }
}
