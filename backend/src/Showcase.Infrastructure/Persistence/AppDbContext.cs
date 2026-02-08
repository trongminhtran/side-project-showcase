using Microsoft.EntityFrameworkCore;
using Showcase.Domain.Comments;
using Showcase.Domain.Projects;
using Showcase.Domain.Ratings;
using Showcase.Domain.Reactions;

namespace Showcase.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Reaction> Reactions => Set<Reaction>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
