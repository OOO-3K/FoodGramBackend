using System.Text.Json;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.BLL.Services;
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

        public HomeController(ILogger<HomeController> logger, IUserService userService, IRecipeService recipeService)
        {
            _logger = logger;
            _userService = userService;
            _recipeService = recipeService;
        }

        [HttpGet("users/")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAll();
            return Ok(JsonSerializer.Serialize(users));
        }

        [HttpGet("recipes/")]
        public IActionResult GetRecipes()
        {
            var recipes = _recipeService.GetAll();
            return Ok(JsonSerializer.Serialize(recipes));
        }
    }
}
