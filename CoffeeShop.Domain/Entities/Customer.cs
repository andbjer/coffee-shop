namespace CoffeeShop.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public IList<Order> Orders { get; set; } = new List<Order>();
}
