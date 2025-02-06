using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Orders.Queries;

public record GetOrders : IRequest<IList<Order>>;

public class GetOrdersHandler(ICoffeeShopDbContext context)
    : IRequestHandler<GetOrders, IList<Order>>
{
    public async Task<IList<Order>> Handle(GetOrders request, CancellationToken cancellationToken)
    {
        return await context
            .Orders.AsNoTracking()
            .OrderBy(x => x.Created)
            .ToListAsync(cancellationToken);
    }
}
