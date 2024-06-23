using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Infra.DataModels.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MetafrasiSS.Infra.Persistence;

public class IdDataContext : IdentityDbContext<DataUserModel, IdentityRole<Guid>, Guid>
{
    public IdDataContext(DbContextOptions<IdDataContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(IdDataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}