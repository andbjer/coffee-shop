using CoffeeShop.Application.Orders.Queries;

namespace CoffeeShop.Drinks;

[ExtendObjectType(typeof(Drink))]
public class DrinkResolvers
{
    public async Task<IList<Order>?> GetOrders(
        [Parent] Drink drink,
        IMediator mediator,
        CancellationToken ct
    )
    {
        return await mediator.Send(new GetOrdersByDrinkId(drink.Id), ct);
    }
}
