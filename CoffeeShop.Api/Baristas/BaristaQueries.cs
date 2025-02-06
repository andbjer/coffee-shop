using CoffeeShop.Application.Baristas.Queries;

namespace CoffeeShop.Baristas;

[QueryType]
public static class BaristaQueries
{
    public static async Task<IList<Barista>> GetBaristas(IMediator mediator, CancellationToken ct)
    {
        return await mediator.Send(new GetBaristas(), ct);
    }
}
