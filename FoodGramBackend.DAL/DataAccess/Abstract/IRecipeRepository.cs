using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IRecipeRepository : IRepository<RecipeEntity>
{
    public RecipeEntity GetById(Guid id);
    public IEnumerable<RecipeEntity> GetByQuery(RecipeDbQuery recipeDbQuery);
}