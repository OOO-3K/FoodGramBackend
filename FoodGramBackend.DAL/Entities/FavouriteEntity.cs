namespace FoodGramBackend.DAL.Entities;

public class FavouriteEntity
{
    public Guid UserId { get; set; }

    public UserEntity User { get; set; }

    public Guid RecipeId { get; set; }

    public RecipeEntity Recipe { get; set; }
}