using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.BLL.Models;

public class RecipeIngredient
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Unit { get; set; }

    public double Amount { get; set; }
}