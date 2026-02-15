using Microsoft.EntityFrameworkCore;
using Showcase.Api.Middleware;
using Showcase.Application.Comments;
using Showcase.Application.Comments.Commands;
using Showcase.Application.Projects;
using Showcase.Application.Projects.Commands;
using Showcase.Application.Ratings;
using Showcase.Application.Ratings.Commands;
using Showcase.Application.Reactions;
using Showcase.Application.Reactions.Commands;
using Showcase.Infrastructure.Persistence;
using Showcase.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// Register command handlers
builder.Services.AddScoped<CreateProjectCommandHandler>();
builder.Services.AddScoped<ReactProjectCommandHandler>();
builder.Services.AddScoped<RateProjectCommandHandler>();
builder.Services.AddScoped<CommentProjectCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
