﻿using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IScoreRepository : IRepository<ScoreEntity>
{
    public IEnumerable<ScoreEntity> GetByRecipeId(Guid recipeId);
}