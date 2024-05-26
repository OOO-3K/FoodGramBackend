namespace FoodGramBackend.BLL.Models;

public class FavouriteQuery
{
    public Guid UserId { get; set; }
    public Guid? RecipeId { get; set; }
}