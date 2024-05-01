using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IRecipeRepository : IRepository<RecipeEntity>
{
    public RecipeEntity GetById(Guid id);
}