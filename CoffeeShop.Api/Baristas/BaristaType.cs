using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Baristas;

public class BaristaType : ObjectType<Barista>
{
    protected override void Configure(IObjectTypeDescriptor<Barista> descriptor)
    {
        descriptor.Field(f => f.Id);
        descriptor.Field(f => f.Name);
    }
}
