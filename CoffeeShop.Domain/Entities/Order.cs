namespace CoffeeShop.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
    public Guid CustomerId { get; set; }
    public Guid DrinkId { get; set; }
    public Guid? BaristaId { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? Updated { get; set; }

    public Customer? Customer { get; set; }
    public Drink? Drink { get; set; }
    public Barista? Barista { get; set; }
}
