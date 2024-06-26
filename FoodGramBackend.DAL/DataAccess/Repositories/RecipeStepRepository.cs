﻿using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Repositories;

public class RecipeStepRepository : IRecipeStepRepository
{
    private readonly FoodGramDbContext _context;

    public RecipeStepRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public List<RecipeStepEntity> GetAll()
    {
        return _context.RecipeSteps.ToList();
    }

    public List<RecipeStepEntity> GetByRecipeId(Guid recipeId)
    {
        return _context.RecipeSteps.Where(x => x.RecipeId == recipeId).OrderBy(x => x.StepNumber).ToList();
    }

    public void Save(RecipeStepEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(RecipeStepEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(RecipeStepEntity entity)
    {
        throw new NotImplementedException();
    }
}