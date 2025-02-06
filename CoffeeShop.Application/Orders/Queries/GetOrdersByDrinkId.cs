using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Orders.Queries;

public record GetOrdersByDrinkId(Guid DrinkId) : IRequest<List<Order>?>;

public class GetOrdersByDrinkIdHandler(IOrdersByDrinkIdDataLoader dataLoader)
    : IRequestHandler<GetOrdersByDrinkId, List<Order>?>
{
    public Task<List<Order>?> Handle(
        GetOrdersByDrinkId request,
        CancellationToken cancellationToken
    )
    {
        return dataLoader.LoadAsync(request.DrinkId, cancellationToken);
    }
}
