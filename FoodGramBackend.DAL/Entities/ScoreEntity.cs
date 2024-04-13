namespace FoodGramBackend.DAL.Entities;

public class ScoreEntity
{
    public Guid UserId { get; set; }

    public UserEntity User { get; set; }

    public Guid RecipeId { get; set; }

    public RecipeEntity Recipe { get; set; }

    public int ScoreValue { get; set; }
}