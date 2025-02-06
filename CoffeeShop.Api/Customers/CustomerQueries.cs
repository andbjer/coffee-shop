using CoffeeShop.Application.Customers.Queries;

namespace CoffeeShop.Customers;

[QueryType]
public static class CustomerQueries
{
    public static async Task<IList<Customer>> GetCustomers(IMediator mediator, CancellationToken ct)
    {
        return await mediator.Send(new GetCustomers(), ct);
    }
}
