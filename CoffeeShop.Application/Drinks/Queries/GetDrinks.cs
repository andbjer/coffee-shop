using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Drinks.Queries;

public record GetDrinks : IRequest<IList<Drink>>;

public class GetDrinksHandler(ICoffeeShopDbContext context)
    : IRequestHandler<GetDrinks, IList<Drink>>
{
    public async Task<IList<Drink>> Handle(GetDrinks request, CancellationToken cancellationToken)
    {
        return await context
            .Drinks.AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}
