using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IRecipeStepRepository : IRepository<RecipeStepEntity>
{
    public IEnumerable<RecipeStepEntity> GetByRecipeId(Guid recipeId);
}