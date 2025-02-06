using CoffeeShop.Domain.Entities;
using GreenDonut;

namespace CoffeeShop.Application.Baristas.Queries;

public record GetBaristaById(Guid BaristaId) : IRequest<Barista>;

public class GetBaristaByIdHandler(IBaristaByIdDataLoader dataLoader)
    : IRequestHandler<GetBaristaById, Barista>
{
    public Task<Barista> Handle(GetBaristaById request, CancellationToken cancellationToken)
    {
        return dataLoader.LoadRequiredAsync(request.BaristaId, cancellationToken);
    }
}
