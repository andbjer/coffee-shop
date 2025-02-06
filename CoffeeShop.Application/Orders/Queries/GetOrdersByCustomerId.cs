using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Orders.Queries;

public record GetOrdersByCustomerId(Guid CustomerId) : IRequest<List<Order>?>;

public class GetOrdersByCustomerIdHandler(IOrdersByCustomerIdDataLoader dataLoader)
    : IRequestHandler<GetOrdersByCustomerId, List<Order>?>
{
    public Task<List<Order>?> Handle(
        GetOrdersByCustomerId request,
        CancellationToken cancellationToken
    )
    {
        return dataLoader.LoadAsync(request.CustomerId, cancellationToken);
    }
}
