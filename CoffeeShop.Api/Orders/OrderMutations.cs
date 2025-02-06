using CoffeeShop.Application.Orders.Models;
using CoffeeShop.Application.Orders.Mutations;
using CoffeeShop.Application.Orders.Queries;

namespace CoffeeShop.Orders;

[MutationType]
public static class OrderMutations
{
    public static async Task<Order> AddOrder(
        AddOrderInput input,
        IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        var orderId = await mediator.Send(new AddOrder(input), cancellationToken);
        return await mediator.Send(new GetOrderById(orderId), cancellationToken);
    }
}
