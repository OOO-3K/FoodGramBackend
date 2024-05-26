using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IScoreRepository : IRepository<ScoreEntity>
{
    public List<ScoreEntity> GetByRecipeId(Guid recipeId);
}