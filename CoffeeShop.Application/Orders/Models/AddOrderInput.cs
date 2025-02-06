namespace CoffeeShop.Application.Orders.Models;

public record AddOrderInput(Guid CustomerId, Guid DrinkId);
