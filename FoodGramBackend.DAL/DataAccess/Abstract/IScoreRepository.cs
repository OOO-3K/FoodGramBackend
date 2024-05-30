using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IScoreRepository : IRepository<ScoreEntity>
{
    public List<ScoreEntity> GetByQuery(ScoreDbQuery scoreDbQuery);
}