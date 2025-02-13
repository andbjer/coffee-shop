using CoffeeShop.Domain.Entities;
using GreenDonut;

namespace CoffeeShop.Application.Orders.Queries;

public record GetOrderById(int OrderId) : IRequest<Order>;

public class GetOrderByIdHandler(IOrderByIdDataLoader dataLoader)
    : IRequestHandler<GetOrderById, Order>
{
    public Task<Order> Handle(GetOrderById request, CancellationToken cancellationToken)
    {
        return dataLoader.LoadRequiredAsync(request.OrderId, cancellationToken);
    }
}
