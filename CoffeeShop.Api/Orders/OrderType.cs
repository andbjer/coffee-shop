using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Orders;

public class OrderType : ObjectType<Order>
{
    protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
    {
        descriptor.Field(f => f.Id);
        descriptor.Field(f => f.Status);
        descriptor.Field(f => f.Created);
        descriptor.Field(f => f.Updated);
    }
}
