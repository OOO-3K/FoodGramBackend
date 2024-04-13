using FoodGramBackend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodGramBackend.DAL.DataContext;

public class FoodGramDbContext : DbContext
{
    public FoodGramDbContext()
    {
        
    }

    public FoodGramDbContext(DbContextOptions<FoodGramDbContext> options) : base(options)
    {
        
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<RecipeEntity> Recipes { get; set; }
    public DbSet<RecipeIngredientsEntity> RecipeIngredients { get;set; }
    public DbSet<ScoreEntity> Scores { get; set; }
    public DbSet<FavouriteEntity> Favourites { get; set; }
    public DbSet<RecipeStepEntity> RecipeSteps { get; set; }
    public DbSet<RecipeCommentEntity> RecipeComments { get; set; }
    public DbSet<RecipeStepComment> RecipeStepComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        modelBuilder.Entity<IngredientEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        modelBuilder.Entity<RecipeEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        modelBuilder.Entity<RecipeIngredientsEntity>(entity =>
        {
            entity.HasKey(e => new {e.IngredientId, e.RecipeId});
        });
        modelBuilder.Entity<RecipeStepEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        modelBuilder.Entity<ScoreEntity>(entity =>
        {
            entity.HasKey(e => new {e.UserId, e.RecipeId});
        });
        modelBuilder.Entity<FavouriteEntity>(entity =>
        {
            entity.HasKey(e => new {e.UserId, e.RecipeId});
        });
        modelBuilder.Entity<RecipeCommentEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        modelBuilder.Entity<RecipeStepComment>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

    }

}