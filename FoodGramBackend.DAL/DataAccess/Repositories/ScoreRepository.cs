using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;

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

    public List<ScoreEntity> GetByQuery(ScoreDbQuery scoreDbQuery)
    {
        var dbQuery = _context.Scores.AsQueryable();

        if (scoreDbQuery.UserId.HasValue)
        {
            dbQuery = dbQuery.Where(x => x.UserId == scoreDbQuery.UserId);
        }

        dbQuery = dbQuery.Where(x => x.RecipeId == scoreDbQuery.RecipeId);

        return dbQuery.ToList();
    }

    public void Save(ScoreEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(ScoreEntity entity)
    {
        _context.Scores.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(ScoreEntity entity)
    {
        throw new NotImplementedException();
    }
}