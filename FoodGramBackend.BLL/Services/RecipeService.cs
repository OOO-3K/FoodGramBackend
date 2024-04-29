using AutoMapper;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.DataAccess;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.BLL.Services;

public class RecipeService : IRecipeService
{
    private readonly IRepository<RecipeEntity> _repositoryRepository;
    private readonly IRecipeIngredientRepository _recipeIngredientRepository;
    private readonly IMapper _mapper;

    public RecipeService(IMapper mapper, IRepository<RecipeEntity> recipeRepository, IRecipeIngredientRepository recipeIngredientRepository)
    {
        _mapper = mapper;
        _repositoryRepository = recipeRepository;
        _recipeIngredientRepository = recipeIngredientRepository;
    }

    public IEnumerable<Recipe> GetAll()
    {
        var recipes = _mapper.Map<List<RecipeEntity>, List<Recipe>>(_repositoryRepository.GetAll().ToList());

        foreach (var recipe in recipes)
        {
            recipe.Ingredients = _mapper.Map<List<RecipeIngredient>>(_recipeIngredientRepository.GetByRecipeId(recipe.Id).ToList());
        }

        return recipes;
    }
}