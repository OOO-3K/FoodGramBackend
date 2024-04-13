using FoodGramBackend.DAL.DataAccess;
using FoodGramBackend.DAL.DataContext;
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
            services.AddScoped<IRepository<RecipeEntity>, RecipeRepository>();
            services.AddDbContext<FoodGramDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("FoodGramDb"));
            });
            return services;
        }
    }
}