using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.DataAccess.Repositories;
using FoodGramBackend.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodGramBackend.DAL
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<UserEntity>, UserRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddScoped<IRecipeStepRepository, RecipeStepRepository>();
            services.AddScoped<IRepository<IngredientEntity>, IngredientRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();
            services.AddDbContext<FoodGramDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("FoodGramDb"));
            });
            return services;
        }
    }
}