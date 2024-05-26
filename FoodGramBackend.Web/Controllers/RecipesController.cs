using AutoMapper;
using FoodGramBackend.BLL.Abstract;
using FoodGramBackend.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FoodGramBackend.BLL.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodGramBackend.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipesController(ILogger<RecipesController> logger, IMapper mapper, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(Guid id)
        {
            var recipes = _recipeService.GetById(id);

            if (recipes == null)
            {
                _logger.LogError($"Found no recipe with id: {id}.");
                return NotFound();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(recipes));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] RecipeQueryEm recipeQuery)
        {
            var ingredients = recipeQuery.Ingredients[0] ?? null;

            if (ingredients != null)
            {
                recipeQuery.Ingredients = JsonSerializer.Deserialize<string[]>(ingredients);
            }
            if (recipeQuery.Ingredients.Length == 0)
            {
                recipeQuery.Ingredients = null;
            } 
            
            var recipes = _recipeService.GetByQuery(_mapper.Map<RecipeQuery>(recipeQuery));

            if (recipes == null)
            {
                _logger.LogError("Couldn't get any recipe.");
                return NotFound();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(recipes));
            }
        }

        [HttpGet("favourites")]
        [Authorize]
        public IActionResult GetFavourites()
        {
            var recipes = _recipeService.GetFavouriteRecipes(new Guid(HttpContext.User.Identity.Name));

            if (recipes == null)
            {
                _logger.LogError("Couldn't get favourite recipes.");
                return NotFound();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(recipes));
            }
        }

        [HttpPut("addToFavourites/{recipeId}")]
        [Authorize]
        public IActionResult AddToFavourites(Guid recipeId)
        {
            _recipeService.AddToFavourites(new Favourite
                {
                    RecipeId = recipeId, 
                    UserId = new Guid(HttpContext.User.Identity.Name)
                });

            return Ok();
        }

        [HttpDelete("deleteFromFavourites/{recipeId}")]
        [Authorize]
        public IActionResult DeleteFromFavourites(Guid recipeId)
        {
            _recipeService.DeleteFromFavourites(new Favourite
            {
                RecipeId = recipeId,
                UserId = new Guid(HttpContext.User.Identity.Name)
            });

            return Ok();
        }
    }
}
