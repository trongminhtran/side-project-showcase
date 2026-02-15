using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Projects;
using Showcase.Domain.Reactions;

namespace Showcase.Infrastructure.Persistence.Configurations;

public sealed class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.ToTable("Reactions");

        builder.HasKey(reaction => reaction.Id);

        builder.Property(reaction => reaction.ProjectId)
            .IsRequired();

        builder.Property(reaction => reaction.UserId)
            .IsRequired();

        builder.Property(reaction => reaction.Type)
            .IsRequired();

        builder.Property(reaction => reaction.CreatedAt)
            .IsRequired();

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(reaction => reaction.ProjectId);

        builder.HasIndex(reaction => new { reaction.ProjectId, reaction.UserId })
            .IsUnique();
    }
}
