using System.Reflection;
using CoffeeShop.Application.Common;

namespace CoffeeShop.Infrastructure.Data;

public class CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
    : DbContext(options),
        ICoffeeShopDbContext
{
    public DbSet<Barista> Baristas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
