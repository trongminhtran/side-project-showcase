using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Showcase.Domain.Comments;

namespace Showcase.Infrastructure.Persistence.Configurations;

public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(comment => comment.Id);

        builder.Property(comment => comment.ProjectId)
            .IsRequired();

        builder.Property(comment => comment.UserId)
            .IsRequired();

        builder.Property(comment => comment.Content)
            .IsRequired();

        builder.Property(comment => comment.CreatedAt)
            .IsRequired();

        builder.Property(comment => comment.ParentCommentId)
            .IsRequired(false);

        builder.HasIndex(comment => comment.ProjectId);
        builder.HasIndex(comment => comment.ParentCommentId);
    }
}
