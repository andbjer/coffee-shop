namespace CoffeeShop.Domain.Entities;

public class Barista
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public IList<Order> Orders { get; set; } = new List<Order>();
}
