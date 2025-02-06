using CoffeeShop.Application.Orders.Queries;

namespace CoffeeShop.Customers;

[ExtendObjectType(typeof(Customer))]
public class CustomerResolvers
{
    public async Task<IList<Order>?> GetOrders(
        [Parent] Customer customer,
        IMediator mediator,
        CancellationToken ct
    )
    {
        return await mediator.Send(new GetOrdersByCustomerId(customer.Id), ct);
    }
}
