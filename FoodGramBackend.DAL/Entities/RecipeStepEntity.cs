namespace FoodGramBackend.DAL.Entities;

public class RecipeStepEntity
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }

    public RecipeEntity Recipe { get; set; }

    public int StepNumber { get; set; }

    public string Name { get; set; }

    public string Decription { get; set; }

    public string? ImagePath { get; set; }

    public double CookingTime { get; set; }
}