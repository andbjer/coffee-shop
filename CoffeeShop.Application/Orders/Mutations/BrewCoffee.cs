using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Enums;
using HotChocolate.Subscriptions;

namespace CoffeeShop.Application.Orders.Mutations;

public record BrewCoffee(int OrderId, TimeSpan BrewingTime) : IRequest;

public class BrewCoffeeHandler(
    ICoffeeShopDbContextFactory dbContextFactory,
    ITopicEventSender eventSender
) : IRequestHandler<BrewCoffee>
{
    public async Task Handle(BrewCoffee request, CancellationToken cancellationToken)
    {
        await Task.Delay(request.BrewingTime, cancellationToken);

        using var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        var order = await context.Orders.SingleAsync(
            x => x.Id == request.OrderId,
            cancellationToken
        );
        if (order.Status != OrderStatus.Pending)
        {
            throw new ApplicationException(
                $"Order with id {request.OrderId} is either finished or not started on"
            );
        }

        order.Status = OrderStatus.Completed;
        order.Updated = DateTimeOffset.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        await eventSender.SendAsync(TopicName.OnOrderUpdated, order.Id, cancellationToken);
    }
}
