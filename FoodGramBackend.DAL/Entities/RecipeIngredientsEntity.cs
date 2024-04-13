namespace FoodGramBackend.DAL.Entities;

public class RecipeIngredientsEntity
{
    public Guid IngredientId { get; set; }

    public IngredientEntity Ingredient { get; set; }

    public Guid RecipeId { get; set; }

    public RecipeEntity Recipe { get; set; }

    public double Amount { get; set; }
}