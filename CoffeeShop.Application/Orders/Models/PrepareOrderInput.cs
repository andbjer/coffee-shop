namespace CoffeeShop.Application.Orders.Models;

public record PrepareOrderInput(Guid OrderId, Guid BaristaId);
