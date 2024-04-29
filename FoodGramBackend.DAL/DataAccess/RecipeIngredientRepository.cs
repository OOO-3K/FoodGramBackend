﻿using FoodGramBackend.DAL.DataContext;
using FoodGramBackend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodGramBackend.DAL.DataAccess;

public class RecipeIngredientRepository : IRecipeIngredientRepository
{

    private readonly FoodGramDbContext _context;

    public RecipeIngredientRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public IEnumerable<RecipeIngredientsEntity> GetAll()
    {
        return _context.RecipeIngredients.ToList();
    }

    public IEnumerable<RecipeIngredientsEntity> GetByRecipeId(Guid recipeId)
    {
        return _context.RecipeIngredients.Where(x => x.RecipeId == recipeId).Include(x => x.Ingredient).ToList();
    }

    public IEnumerable<RecipeIngredientsEntity> GetByIngredientIds(List<Guid> ingredientIds)
    {
        return _context.RecipeIngredients.Where(x => ingredientIds.Contains(x.IngredientId)).ToList();
    }
}