using CoffeeShop.Application.Common;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Application.Baristas.Queries;

public record GetBaristas : IRequest<IList<Barista>>;

public class GetBaristasHandler(ICoffeeShopDbContext context)
    : IRequestHandler<GetBaristas, IList<Barista>>
{
    public async Task<IList<Barista>> Handle(
        GetBaristas request,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Baristas.AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}
