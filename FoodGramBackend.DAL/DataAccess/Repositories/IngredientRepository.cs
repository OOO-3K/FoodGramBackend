using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Repositories;

public class IngredientRepository : IRepository<IngredientEntity>
{
    private readonly FoodGramDbContext _context;

    public IngredientRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public List<IngredientEntity> GetAll()
    {
        return _context.Ingredients.ToList();
    }

    public void Save(IngredientEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(IngredientEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(IngredientEntity entity)
    {
        throw new NotImplementedException();
    }
}