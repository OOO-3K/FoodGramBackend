using FoodGramBackend.BLL.Models;

namespace FoodGramBackend.BLL.Abstract;

public interface IRecipeService : IService<Recipe>
{
    public Recipe GetById(Guid id);
    public IEnumerable<Recipe> GetByQuery(RecipeQuery recipeQuery);
}