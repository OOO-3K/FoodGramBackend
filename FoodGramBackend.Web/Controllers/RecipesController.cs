using AutoMapper;
using FoodGramBackend.BLL.Abstract;
using FoodGramBackend.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FoodGramBackend.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using FoodGramBackend.BLL.Services;

namespace FoodGramBackend.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        private readonly User _testUser;

        public RecipesController(ILogger<RecipesController> logger, IMapper mapper, IRecipeService recipeService, IUserService userService)
        {
            _logger = logger;
            _recipeService = recipeService;
            _mapper = mapper;
            _testUser = userService.GetByQuery(new UserQuery { Name = "Nikita Golova", Password = "TestData" });
        }

        [HttpGet("{id}")]
        //[AllowAnonymous]
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
        //[AllowAnonymous]
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
        //[Authorize]
        public IActionResult GetFavourites()
        {
            var recipes = _recipeService.GetFavouriteRecipes(_testUser.Id);

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

        [HttpGet("favourites/in/{recipeId}")]
        //[Authorize]
        public IActionResult IsInFavourites(Guid recipeId)
        {
            var result = _recipeService.IsInFavourites(new Favourite
            {
                RecipeId = recipeId,
                UserId = _testUser.Id
            });

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpPut("favourites/add/{recipeId}")]
        //[Authorize]
        public IActionResult AddToFavourites(Guid recipeId)
        {
            var favourite = new Favourite
            {
                RecipeId = recipeId,
                UserId = _testUser.Id
            };

            if (!_recipeService.IsInFavourites(favourite))
            {
                _recipeService.AddToFavourites(favourite);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("favourites/delete/{recipeId}")]
        //[Authorize]
        public IActionResult DeleteFromFavourites(Guid recipeId)
        {
            var favourite = new Favourite
            {
                RecipeId = recipeId,
                UserId = _testUser.Id
            };

            if (_recipeService.IsInFavourites(favourite))
            {
                _recipeService.DeleteFromFavourites(favourite);
                return Ok();
            }

            return BadRequest();
        }
    }
}
