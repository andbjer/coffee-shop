using CoffeeShop.Domain.Entities;
using GreenDonut;

namespace CoffeeShop.Application.Customers.Queries;

public record GetCustomerById(Guid CustomerId) : IRequest<Customer>;

public class GetCustomerByIdHandler(ICustomerByIdDataLoader dataLoader)
    : IRequestHandler<GetCustomerById, Customer>
{
    public Task<Customer> Handle(GetCustomerById request, CancellationToken cancellationToken)
    {
        return dataLoader.LoadRequiredAsync(request.CustomerId, cancellationToken);
    }
}
