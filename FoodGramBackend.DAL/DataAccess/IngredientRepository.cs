﻿using FoodGramBackend.DAL.DataContext;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess;

public class IngredientRepository : IRepository<IngredientEntity>
{
    private readonly FoodGramDbContext _context;

    public IngredientRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public IEnumerable<IngredientEntity> GetAll()
    {
        return _context.Ingredients.ToList();
    }

}