using CoffeeShop.Application.Common;
using CoffeeShop.Application.Orders.Models;
using CoffeeShop.Domain.Enums;

namespace CoffeeShop.Application.Orders.Mutations;

public record PrepareOrder(PrepareOrderInput Input) : IRequest;

public class PrepareOrderHandler(ICoffeeShopDbContext context, IMediator mediator)
    : IRequestHandler<PrepareOrder>
{
    public async Task Handle(PrepareOrder request, CancellationToken cancellationToken)
    {
        var order = await context
            .Orders.Include(x => x.Drink)
            .SingleAsync(x => x.Id == request.Input.OrderId, cancellationToken);

        order.BaristaId = request.Input.BaristaId;
        order.Status = OrderStatus.Pending;
        order.Updated = DateTimeOffset.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        _ = mediator.Send(
            new BrewCoffee(
                request.Input.OrderId,
                order.Drink?.PreparationTime ?? TimeSpan.FromMinutes(1)
            ),
            cancellationToken
        );
    }
}
