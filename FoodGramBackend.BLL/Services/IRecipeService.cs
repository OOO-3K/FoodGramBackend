using FoodGramBackend.BLL.Models;

namespace FoodGramBackend.BLL.Services;

public interface IRecipeService : IService<Recipe>
{
    public Recipe GetById(Guid id);
}