using CoffeeShop.Application.Drinks.Queries;

namespace CoffeeShop.Drinks;

[QueryType]
public static class DrinkQueries
{
    public static async Task<IList<Drink>> GetDrinks(IMediator mediator, CancellationToken ct)
    {
        return await mediator.Send(new GetDrinks(), ct);
    }
}
