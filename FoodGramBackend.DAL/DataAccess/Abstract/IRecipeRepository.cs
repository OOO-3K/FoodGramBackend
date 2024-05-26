using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IRecipeRepository : IRepository<RecipeEntity>
{
    public RecipeEntity GetById(Guid id);
    public List<RecipeEntity> GetByIds(IEnumerable<Guid> ids);
    public List<RecipeEntity> GetByQuery(RecipeDbQuery recipeDbQuery);
}