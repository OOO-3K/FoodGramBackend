using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.DataContext;
using FoodGramBackend.DAL.Entities;
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