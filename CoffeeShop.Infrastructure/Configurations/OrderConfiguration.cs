namespace CoffeeShop.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(15);

        builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);
        builder.HasOne(x => x.Drink).WithMany(x => x.Orders).HasForeignKey(x => x.DrinkId);
        builder.HasOne(x => x.Barista).WithMany(x => x.Orders).HasForeignKey(x => x.BaristaId);
    }
}
