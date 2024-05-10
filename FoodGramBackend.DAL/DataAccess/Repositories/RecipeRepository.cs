using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodGramBackend.DAL.DataAccess.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly FoodGramDbContext _context;

    public RecipeRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public IEnumerable<RecipeEntity> GetAll()
    {
        return _context.Recipes.AsNoTracking().ToList();
    }

    public RecipeEntity GetById(Guid id)
    {
        return _context.Recipes.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<RecipeEntity> GetByQuery(RecipeDbQuery recipeDbQuery)
    {
        var recipes = _context.Recipes.AsQueryable();

        if (recipeDbQuery.Name != null)
        {
            recipes = recipes.Where(x => x.Name.ToLower().Contains(recipeDbQuery.Name.ToLower().Trim()));
        }
        if (recipeDbQuery.CookingTimeFrom != null)
        {
            recipes = recipes.Where(x => x.CookingTime >= recipeDbQuery.CookingTimeFrom);
        }
        if (recipeDbQuery.CookingTimeTo != null)
        {
            recipes = recipes.Where(x => x.CookingTime <= recipeDbQuery.CookingTimeTo);
        }
        if (recipeDbQuery.RatingFrom != null)
        {
            recipes = recipes.Where(x => x.Rating >= recipeDbQuery.RatingFrom);
        }
        if (recipeDbQuery.RatingTo != null)
        {
            recipes = recipes.Where(x => x.Rating <= recipeDbQuery.RatingTo);
        }
        return recipes.ToList();
    }

    public void Update(RecipeEntity entity)
    {
        _context.Recipes.Update(entity);
        _context.SaveChanges();
    }

    public void Save(RecipeEntity entity)
    {
        _context.Recipes.Add(entity);
        _context.SaveChanges();
    }
}