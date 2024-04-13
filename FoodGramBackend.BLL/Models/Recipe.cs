namespace FoodGramBackend.BLL.Models;

public class Recipe
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string? ImagePath { get; set; }

    public double CookingTime { get; set; }

    public int? Rating { get; set; }
}