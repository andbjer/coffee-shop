namespace CoffeeShop.Infrastructure.Configurations;

public class BaristaConfiguration : IEntityTypeConfiguration<Barista>
{
    public void Configure(EntityTypeBuilder<Barista> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50);
    }
}
