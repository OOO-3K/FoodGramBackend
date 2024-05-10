using System.Text.Json;
using AutoMapper;
using FoodGramBackend.BLL.Abstract;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodGramBackend.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IUserService userService, IRecipeService recipeService)
        {
            _logger = logger;
            _userService = userService;
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet("users/")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAll();
            return Ok(JsonSerializer.Serialize(users));
        }

        //[HttpGet("recipes/")]
        //public IActionResult GetRecipes()
        //{
        //    var recipes = _recipeService.GetAll();
        //    return Ok(JsonSerializer.Serialize(recipes));
        //}

        [HttpGet("recipes/{id}")]
        public IActionResult GetRecipes(Guid id)
        {
            var recipes = _recipeService.GetById(id);

            if (recipes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(recipes));
            }
        }

        [HttpGet("recipes/")]
        public IActionResult GetRecipes([FromQuery] RecipeQueryEm recipeQuery)
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
                return NotFound();
            }
            else
            {
                return Ok(JsonSerializer.Serialize(recipes));
            }
        }
    }
}
