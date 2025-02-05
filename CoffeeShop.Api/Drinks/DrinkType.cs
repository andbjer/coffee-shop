using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Drinks;

public class DrinkType : ObjectType<Drink>
{
    protected override void Configure(IObjectTypeDescriptor<Drink> descriptor)
    {
        descriptor.Field(f => f.Id);
        descriptor.Field(f => f.Name);
        descriptor.Field(f => f.Description);
        descriptor.Field(f => f.Price);
        descriptor.Field(f => f.CaffeineLevel);
    }
}
