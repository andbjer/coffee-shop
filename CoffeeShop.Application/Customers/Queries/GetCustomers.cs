using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Customers.Queries;

public record GetCustomers : IRequest<IList<Customer>>;

public class GetCustomersHandler(ICoffeeShopDbContext context)
    : IRequestHandler<GetCustomers, IList<Customer>>
{
    public async Task<IList<Customer>> Handle(
        GetCustomers request,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Customers.AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}
