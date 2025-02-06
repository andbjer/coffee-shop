using CoffeeShop.Application.Customers.Commands;
using CoffeeShop.Application.Customers.Models;
using CoffeeShop.Application.Customers.Queries;

namespace CoffeeShop.Customers;

[MutationType]
public static class CustomerMutations
{
    public static async Task<Customer?> AddCustomer(
        AddCustomerInput input,
        IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        var customerId = await mediator.Send(new AddCustomer(input), cancellationToken);
        return await mediator.Send(new GetCustomerById(customerId), cancellationToken);
    }
}
