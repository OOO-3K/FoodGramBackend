namespace FoodGramBackend.DAL.Models;

public class RecipeDbQuery
{
    public string? Name { get; set; }
    public int? RatingFrom { get; set; }
    public int? RatingTo { get; set; }
    public int? CookingTimeFrom { get; set; }
    public int? CookingTimeTo { get; set; }
}