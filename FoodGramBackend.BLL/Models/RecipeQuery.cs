namespace FoodGramBackend.BLL.Models;

public class RecipeQuery
{
    public string? Name { get; set; }
    public int? RatingFrom { get; set; }
    public int? RatingTo { get; set; }
    public int? CookingTimeFrom { get; set; }
    public int? CookingTimeTo { get; set; }
    public string[]? Ingredients { get; set; }
}