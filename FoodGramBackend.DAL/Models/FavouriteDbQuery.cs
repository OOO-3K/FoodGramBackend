namespace FoodGramBackend.DAL.Models;

public class FavouriteDbQuery
{
    public Guid UserId { get; set; }
    public Guid? RecipeId { get; set; }
}