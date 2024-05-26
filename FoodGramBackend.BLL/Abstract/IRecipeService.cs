using FoodGramBackend.BLL.Models;

namespace FoodGramBackend.BLL.Abstract;

public interface IRecipeService : IService<Recipe>
{
    public Recipe GetById(Guid id);
    public List<Recipe> GetFavouriteRecipes(Guid userId);
    public void AddToFavourites(Favourite favourite);
    public void DeleteFromFavourites(Favourite favourite);
    public List<Recipe> GetByQuery(RecipeQuery recipeQuery);
}