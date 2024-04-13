using FoodGramBackend.DAL.DataContext;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess;

public class RecipeRepository : IRepository<RecipeEntity>
{
    private readonly FoodGramDbContext _context;

    public RecipeRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public IEnumerable<RecipeEntity> GetAll()
    {
        return _context.Recipes.ToList();
    }
}