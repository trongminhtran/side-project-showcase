using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Projects;

namespace Showcase.Infrastructure.Persistence.Configurations;

public sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(project => project.Id);

        builder.Property(project => project.OwnerId)
            .IsRequired();

        builder.Property(project => project.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(project => project.Visibility)
            .IsRequired();

        builder.Property(project => project.CreatedAt)
            .IsRequired();

        builder.Property(project => project.Description);

        builder.HasIndex(project => project.OwnerId);
    }
}
