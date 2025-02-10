namespace CoffeeShop.Infrastructure.Configurations;

public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(30);
        builder.Property(x => x.Description).HasMaxLength(120);
        builder.Property(x => x.CaffeineLevel).HasConversion<string>().HasMaxLength(15);

        builder.HasMany(x => x.Orders).WithOne(x => x.Drink).HasForeignKey(x => x.DrinkId);
    }
}
