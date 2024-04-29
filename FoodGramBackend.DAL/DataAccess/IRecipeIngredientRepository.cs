using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess;

public interface IRecipeIngredientRepository : IRepository<RecipeIngredientsEntity>
{
    public IEnumerable<RecipeIngredientsEntity> GetByRecipeId(Guid recipeId);
}