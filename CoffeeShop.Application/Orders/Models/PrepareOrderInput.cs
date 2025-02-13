namespace CoffeeShop.Application.Orders.Models;

public record PrepareOrderInput(int OrderId, Guid BaristaId);
