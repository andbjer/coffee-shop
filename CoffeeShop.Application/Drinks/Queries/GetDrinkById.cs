using CoffeeShop.Domain.Entities;
using GreenDonut;

namespace CoffeeShop.Application.Drinks.Queries;

public record GetDrinkById(Guid DrinkId) : IRequest<Drink>;

public class GetDrinkByIdHandler(IDrinkByIdDataLoader dataLoader)
    : IRequestHandler<GetDrinkById, Drink>
{
    public Task<Drink> Handle(GetDrinkById request, CancellationToken cancellationToken)
    {
        return dataLoader.LoadRequiredAsync(request.DrinkId, cancellationToken);
    }
}
