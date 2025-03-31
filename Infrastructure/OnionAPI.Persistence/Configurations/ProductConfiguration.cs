using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        // default value on postgresql where new entity added
        //builder
        //    .Property(x => x.CreatedAt)
        //    .HasDefaultValueSql("now()")
        //    .ValueGeneratedOnAdd();

        // global filter
        builder
            .HasQueryFilter(x => x.IsDeleted == false);
    }
}
