namespace FoodGramBackend.BLL.Models;

public class ScoreSetModel
{
    public Guid UserId { get; set; }
    public Guid RecipeId { get; set; }
    public int ScoreValue { get; set; }
}