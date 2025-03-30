using Microsoft.EntityFrameworkCore;
using OnionAPI.Domain.Entities;
using OnionAPI.Domain.Entities.Common;

namespace OnionAPI.Persistence.Contexts;

public class AppPostgreDbContext : DbContext
{
    public AppPostgreDbContext(DbContextOptions opt) : base(opt)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppPostgreDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries<BaseEntity>();

        foreach (var entity in entities)
        {
            switch (entity.State)
            {
                case EntityState.Modified:
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entity.Entity.RemovedAt = DateTime.UtcNow;
                    entity.Entity.IsDeleted = true;
                    entity.State = EntityState.Modified; // do not delete, but just moddify
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
