using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Common;

public interface ICoffeeShopDbContext
{
    DbSet<Barista> Baristas { get; set; }
    DbSet<Customer> Customers { get; set; }
    DbSet<Drink> Drinks { get; set; }
    DbSet<Order> Orders { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
