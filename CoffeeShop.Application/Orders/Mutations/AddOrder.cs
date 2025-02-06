using CoffeeShop.Application.Common;
using CoffeeShop.Application.Orders.Models;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Enums;

namespace CoffeeShop.Application.Orders.Mutations;

public record AddOrder(AddOrderInput Input) : IRequest<Guid>;

public class AddOrderHandler(ICoffeeShopDbContext context) : IRequestHandler<AddOrder, Guid>
{
    public async Task<Guid> Handle(AddOrder request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            CustomerId = request.Input.CustomerId,
            DrinkId = request.Input.DrinkId,
            Status = OrderStatus.Ordered,
            Created = DateTimeOffset.UtcNow,
        };

        context.Orders.Add(order);
        await context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
