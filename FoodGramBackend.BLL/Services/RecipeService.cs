using AutoMapper;
using FoodGramBackend.BLL.Abstract;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;

namespace FoodGramBackend.BLL.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IRecipeIngredientRepository _recipeIngredientRepository;
    private readonly IRecipeStepRepository _recipeStepRepository;
    private readonly IScoreRepository _scoreRepository;
    private readonly IFavouriteRepository _favouriteRepository;
    private readonly IMapper _mapper;

    public RecipeService(
        IMapper mapper, 
        IRecipeRepository recipeRepository, 
        IRecipeIngredientRepository recipeIngredientRepository, 
        IRecipeStepRepository recipeStepRepository,
        IScoreRepository scoreRepository,
        IFavouriteRepository favouriteRepository)
    {
        _mapper = mapper;
        _recipeRepository = recipeRepository;
        _recipeIngredientRepository = recipeIngredientRepository;
        _recipeStepRepository = recipeStepRepository;
        _scoreRepository = scoreRepository;
        _favouriteRepository = favouriteRepository;
    }

    public List<Recipe> GetAll()
    {
        var recipes = _mapper.Map<List<RecipeEntity>, List<Recipe>>(_recipeRepository.GetAll().ToList());

        foreach (var recipe in recipes)
        {
            recipe.Ingredients = _mapper.Map<List<RecipeIngredient>>(_recipeIngredientRepository.GetByRecipeId(recipe.Id).ToList());
            //UpdateRecipeCalculatingFields(recipe);
        }

        return recipes;
    }

    public List<Recipe> GetFavouriteRecipes(Guid userId)
    {
        var favourites = _mapper.Map<List<Favourite>>(_favouriteRepository.GetByQuery(new FavouriteDbQuery { UserId = userId }));

        var recipes = _mapper.Map<List<Recipe>>(
            _recipeRepository.GetByIds(favourites.Select(x => x.RecipeId)).ToList());

        foreach (var recipe in recipes)
        {
            recipe.Ingredients = _mapper.Map<List<RecipeIngredient>>(_recipeIngredientRepository.GetByRecipeId(recipe.Id).ToList());
            //UpdateRecipeCalculatingFields(recipe);
        }

        return recipes;
    }

    public void AddToFavourites(Favourite favourite)
    {
        _favouriteRepository.Save(_mapper.Map<FavouriteEntity>(favourite));
    }

    public void DeleteFromFavourites(Favourite favourite)
    {
        _favouriteRepository.Delete(_mapper.Map<FavouriteEntity>(favourite));
    }

    public Recipe GetById(Guid id)
    {
        var recipe = _mapper.Map<RecipeEntity, Recipe>(_recipeRepository.GetById(id));

        if (recipe == null)
            return null;
        
        recipe.Ingredients = _mapper.Map<List<RecipeIngredient>>(_recipeIngredientRepository.GetByRecipeId(recipe.Id).ToList());
        recipe.RecipeSteps = _mapper.Map<List<RecipeStep>>(_recipeStepRepository.GetByRecipeId(recipe.Id)).ToList();
        //UpdateRecipeCalculatingFields(recipe);

        return recipe;
    }

    public List<Recipe> GetByQuery(RecipeQuery recipeQuery)
    {
        var recipes = _mapper.Map<List<Recipe>>(_recipeRepository.GetByQuery(_mapper.Map<RecipeDbQuery>(recipeQuery)).ToList());

        var recipesResult = new List<Recipe>();

        recipesResult.AddRange(recipes);

        foreach (var recipe in recipes)
        {
            recipe.Ingredients = _mapper.Map<List<RecipeIngredient>>(_recipeIngredientRepository.GetByRecipeId(recipe.Id).ToList());

            if (recipeQuery.Ingredients != null && recipeQuery.Ingredients.Length > 0)
            {
                foreach (var recipeQueryIngredient in recipeQuery.Ingredients)
                {
                    var result = recipe.Ingredients.Where(x => x.Name.ToLower().Contains(recipeQueryIngredient.ToLower().Trim()));
                    if (!result.Any())
                    {
                        recipesResult.Remove(recipe);
                    }
                }
            }
            //UpdateRecipeCalculatingFields(recipe);
        }

        return recipesResult;
    }

    public void UpdateRecipeCalculatingFields(Recipe recipe)
    {
        CalculateCookingTime(recipe);
        CalculateRating(recipe);
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
                _recipeRepository.Update(_mapper.Map<RecipeEntity>(recipe));
            }
        }
    }

    private void CalculateRating(Recipe recipe)
    {
        var scoreList = _scoreRepository.GetByRecipeId(recipe.Id);

        if (scoreList.Any())
        {
            var sum = 0;
            foreach (var scoreEntity in scoreList)
            {
                sum += scoreEntity.ScoreValue;
            }

            var rating = sum / scoreList.Count();

            if (recipe.Rating != rating)
            {
                recipe.Rating = rating;
                _recipeRepository.Update(_mapper.Map<RecipeEntity>(recipe));
            }
        }
    }
}