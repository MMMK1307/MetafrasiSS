using MetafrasiSS.Domain.ProjectAggregate;
using MetafrasiSS.Domain.ProjectAggregate.ValueObjects;
using MetafrasiSS.Infra.DataModels.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetafrasiSS.Infra.Persistence.Configuration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        ConfigureProjectTable(builder);
        ConfigureProjectFilesTables(builder);
    }

    private void ConfigureProjectTable(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProjectId.Create(value));

        builder.Property(x => x.Name)
            .HasMaxLength(256);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.Updated);

        builder.Property(x => x.Created);

        builder.Ignore(x => x.UserId);

        builder.HasOne<DataUserModel>().WithMany().HasForeignKey("_userId");
    }

    private void ConfigureProjectFilesTables(EntityTypeBuilder<Project> builder)
    {
        builder.OwnsMany(x => x.Files, fb =>
        {
            fb.ToTable("ProjectFiles");
            fb.WithOwner().HasForeignKey("ProjectId");

            fb.HasKey("Id", "ProjectId");

            fb.Property(x => x.Id)
                .HasColumnName("ProjectFileId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProjectFileId.Create(value));

            fb.Property(x => x.Name)
            .HasMaxLength(256);

            fb.Property(x => x.Content);

            fb.Property(x => x.Updated);

            fb.Property(x => x.Created);
        });

        builder.Metadata.FindNavigation(nameof(Project.Files))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}