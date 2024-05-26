namespace FoodGramBackend.BLL.Models;

public class RecipeStep
{
    public Guid Id { get; set; }

    public int StepNumber { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string? ImagePath { get; set; }

    public double CookingTime { get; set; }
}