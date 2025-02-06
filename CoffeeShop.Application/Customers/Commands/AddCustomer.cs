using CoffeeShop.Application.Common;
using CoffeeShop.Application.Customers.Models;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Customers.Commands;

public record AddCustomer(AddCustomerInput Input) : IRequest<Guid>;

public class AddCustomerHandler(ICoffeeShopDbContext context) : IRequestHandler<AddCustomer, Guid>
{
    public async Task<Guid> Handle(AddCustomer request, CancellationToken cancellationToken)
    {
        var customer = new Customer { Name = request.Input.Name, Email = request.Input.Email };

        context.Customers.Add(customer);
        await context.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
