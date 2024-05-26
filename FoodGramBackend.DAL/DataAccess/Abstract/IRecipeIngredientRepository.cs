using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IRecipeIngredientRepository : IRepository<RecipeIngredientsEntity>
{
    public List<RecipeIngredientsEntity> GetByRecipeId(Guid recipeId);
}