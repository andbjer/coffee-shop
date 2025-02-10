namespace CoffeeShop.Domain.Entities;

public class Drink
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public double Price { get; set; }
    public CaffeineLevel CaffeineLevel { get; set; }
    public TimeSpan PreparationTime { get; set; }

    public IList<Order> Orders { get; set; } = new List<Order>();
}
