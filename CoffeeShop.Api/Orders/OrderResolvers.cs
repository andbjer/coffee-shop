using CoffeeShop.Application.Baristas.Queries;
using CoffeeShop.Application.Customers.Queries;
using CoffeeShop.Application.Drinks.Queries;

namespace CoffeeShop.Orders;

[ExtendObjectType(typeof(Order))]
public class OrderResolvers
{
    public async Task<Customer?> GetCustomer(
        [Parent] Order order,
        IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(new GetCustomerById(order.CustomerId), cancellationToken);
    }

    public async Task<Drink?> GetDrink(
        [Parent] Order order,
        IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(new GetDrinkById(order.DrinkId), cancellationToken);
    }

    public async Task<Barista?> GetBarista(
        [Parent] Order order,
        IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        if (!order.BaristaId.HasValue)
        {
            return null;
        }

        return await mediator.Send(new GetBaristaById(order.BaristaId.Value), cancellationToken);
    }
}
