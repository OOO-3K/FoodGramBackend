using AutoMapper;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.BLL.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repositoryRepository;
    private readonly IRecipeIngredientRepository _recipeIngredientRepository;
    private readonly IRecipeStepRepository _recipeStepRepository;
    private readonly IMapper _mapper;

    public RecipeService(IMapper mapper, IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository, IRecipeStepRepository recipeStepRepository)
    {
        _mapper = mapper;
        _repositoryRepository = recipeRepository;
        _recipeIngredientRepository = recipeIngredientRepository;
        _recipeStepRepository = recipeStepRepository;
    }

    public IEnumerable<Recipe> GetAll()
    {
        var recipes = _mapper.Map<List<RecipeEntity>, List<Recipe>>(_repositoryRepository.GetAll().ToList());

        foreach (var recipe in recipes)
        {
            recipe.Ingredients = _mapper.Map<List<RecipeIngredient>>(_recipeIngredientRepository.GetByRecipeId(recipe.Id).ToList());
            //recipe.RecipeSteps = _mapper.Map<List<RecipeStep>>(_recipeStepRepository.GetByRecipeId(recipe.Id)).ToList();
            //CalculateCookingTime(recipe);
        }

        return recipes;
    }

    public Recipe GetById(Guid id)
    {
        var recipe = _mapper.Map<RecipeEntity, Recipe>(_repositoryRepository.GetById(id));

        if (recipe == null)
            return null;
        
        recipe.Ingredients = _mapper.Map<List<RecipeIngredient>>(_recipeIngredientRepository.GetByRecipeId(recipe.Id).ToList());
        recipe.RecipeSteps = _mapper.Map<List<RecipeStep>>(_recipeStepRepository.GetByRecipeId(recipe.Id)).ToList();
        //CalculateCookingTime(recipe);

        return recipe;
    }

    private void CalculateCookingTime(Recipe recipe)
    {
        if (recipe.RecipeSteps.Any())
        {
            var cookingTime = 0.0;

            foreach (var recipeStep in recipe.RecipeSteps)
            {
                cookingTime += recipeStep.CookingTime;
            }

            if (recipe.CookingTime != cookingTime)
            {
                recipe.CookingTime = cookingTime;
                _repositoryRepository.Update(_mapper.Map<RecipeEntity>(recipe));
            }
        }
    }
}