namespace CoffeeShop.Infrastructure.Configurations;

public class BaristaConfiguration : IEntityTypeConfiguration<Barista>
{
    public void Configure(EntityTypeBuilder<Barista> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50);

        builder.HasMany(x => x.Orders).WithOne(x => x.Barista).HasForeignKey(x => x.BaristaId);
    }
}
