using CoffeeShop.Application.Orders.Queries;

namespace CoffeeShop.Baristas;

[ExtendObjectType(typeof(Barista))]
public class BaristaResolvers
{
    public async Task<IList<Order>?> GetOrders(
        [Parent] Barista barista,
        IMediator mediator,
        CancellationToken ct
    )
    {
        return await mediator.Send(new GetOrdersByBaristaId(barista.Id), ct);
    }
}
