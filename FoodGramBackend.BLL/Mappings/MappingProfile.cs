using AutoMapper;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;

namespace FoodGramBackend.BLL.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, User>();

        CreateMap<RecipeEntity, Recipe>();

        CreateMap<Recipe, RecipeEntity>();

        CreateMap<IngredientEntity, Ingredient>();

        CreateMap<RecipeIngredientsEntity, RecipeIngredient>()
            .ForMember(x => x.Id, opt => opt.MapFrom(ing => ing.Ingredient.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(ing => ing.Ingredient.Name))
            .ForMember(x => x.Unit, opt => opt.MapFrom(ing => ing.Ingredient.Unit));

        CreateMap<RecipeStepEntity, RecipeStep>();

        CreateMap<RecipeDbQuery, RecipeQuery>().ReverseMap();
    }
}