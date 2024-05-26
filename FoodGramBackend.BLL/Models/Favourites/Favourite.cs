namespace FoodGramBackend.BLL.Models;

public class Favourite
{
    public Guid UserId { get; set; }
    public Guid RecipeId { get; set; }
}