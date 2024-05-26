using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Repositories;

public class ScoreRepository : IScoreRepository
{
    private readonly FoodGramDbContext _context;

    public ScoreRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public List<ScoreEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<ScoreEntity> GetByRecipeId(Guid recipeId)
    {
        return _context.Scores.Where(x => x.RecipeId == recipeId).ToList();
    }

    public void Save(ScoreEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(ScoreEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ScoreEntity entity)
    {
        throw new NotImplementedException();
    }
}