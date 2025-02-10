using CoffeeShop.Application.Common;
using CoffeeShop.Application.Orders.Queries;

namespace CoffeeShop.Orders;

[SubscriptionType]
public static class OrderSubscriptions
{
    [Subscribe] // tells schema builder that this resolver method needs to be hooked up to the pub/sub system
    [Topic(TopicName.OnOrderUpdated)]
    public static async Task<Order> OnOrderUpdatedAsync(
        [EventMessage] Guid orderId,
        IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(new GetOrderById(orderId), cancellationToken);
    }
}
