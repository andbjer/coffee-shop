using CoffeeShop.Application.Orders.Queries;

namespace CoffeeShop.Orders;

[QueryType]
public static class OrderQueries
{
    public static async Task<IList<Order>> GetOrders(IMediator mediator, CancellationToken ct)
    {
        return await mediator.Send(new GetOrders(), ct);
    }
}
