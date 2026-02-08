using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Ratings;

namespace Showcase.Infrastructure.Persistence.Configurations;

public sealed class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("Ratings");

        builder.HasKey(rating => rating.Id);

        builder.Property(rating => rating.ProjectId)
            .IsRequired();

        builder.Property(rating => rating.UserId)
            .IsRequired();

        builder.Property(rating => rating.Score)
            .IsRequired();

        builder.Property(rating => rating.CreatedAt)
            .IsRequired();

        builder.HasIndex(rating => new { rating.ProjectId, rating.UserId })
            .IsUnique();
    }
}
