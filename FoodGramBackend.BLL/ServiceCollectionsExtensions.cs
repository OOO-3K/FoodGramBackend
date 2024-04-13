﻿using AutoMapper;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.BLL.Services;
using FoodGramBackend.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodGramBackend.BLL
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories(configuration);
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IService<User>, UserService>();
            services.AddScoped<IService<Recipe>, RecipeService>();
            return services;
        }
    }
}
