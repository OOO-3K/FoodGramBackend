﻿using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodGramBackend.DAL.DataAccess.Repositories;

public class RecipeIngredientRepository : IRecipeIngredientRepository
{

    private readonly FoodGramDbContext _context;

    public RecipeIngredientRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public List<RecipeIngredientsEntity> GetAll()
    {
        return _context.RecipeIngredients.ToList();
    }

    public List<RecipeIngredientsEntity> GetByRecipeId(Guid recipeId)
    {
        return _context.RecipeIngredients.Where(x => x.RecipeId == recipeId).Include(x => x.Ingredient).ToList();
    }

    public List<RecipeIngredientsEntity> GetByIngredientIds(List<Guid> ingredientIds)
    {
        return _context.RecipeIngredients.Where(x => ingredientIds.Contains(x.IngredientId)).ToList();
    }

    public void Update(RecipeIngredientsEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Save(RecipeIngredientsEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(RecipeIngredientsEntity entity)
    {
        throw new NotImplementedException();
    }
}