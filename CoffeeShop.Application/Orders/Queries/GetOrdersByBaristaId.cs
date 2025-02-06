using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Orders.Queries;

public record GetOrdersByBaristaId(Guid BaristaId) : IRequest<List<Order>?>;

public class GetOrdersByBaristaIdHandler(IOrdersByBaristaIdDataLoader dataLoader)
    : IRequestHandler<GetOrdersByBaristaId, List<Order>?>
{
    public Task<List<Order>?> Handle(
        GetOrdersByBaristaId request,
        CancellationToken cancellationToken
    )
    {
        return dataLoader.LoadAsync(request.BaristaId, cancellationToken);
    }
}
