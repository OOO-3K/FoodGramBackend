using FoodGramBackend.DAL.DataContext;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess;

public class RecipeStepRepository : IRepository<RecipeStepEntity>
{
    private readonly FoodGramDbContext _context;

    public RecipeStepRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public IEnumerable<RecipeStepEntity> GetAll()
    {
        return _context.RecipeSteps.ToList();
    }

    public IEnumerable<RecipeStepEntity> GetByRecipeId(Guid recipeId)
    {
        return _context.RecipeSteps.Where(x => x.RecipeId == recipeId).ToList();
    }
}