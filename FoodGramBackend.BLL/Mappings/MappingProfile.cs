using AutoMapper;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;

namespace FoodGramBackend.BLL.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, User>().ReverseMap();

        CreateMap<RecipeEntity, Recipe>().ReverseMap();

        CreateMap<IngredientEntity, Ingredient>().ReverseMap();

        CreateMap<RecipeIngredientsEntity, RecipeIngredient>()
            .ForMember(x => x.Id, opt => opt.MapFrom(ing => ing.Ingredient.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(ing => ing.Ingredient.Name))
            .ForMember(x => x.Unit, opt => opt.MapFrom(ing => ing.Ingredient.Unit))
            .ReverseMap();

        CreateMap<RecipeStepEntity, RecipeStep>().ReverseMap();

        CreateMap<RecipeDbQuery, RecipeQuery>().ReverseMap();

        CreateMap<FavouriteDbQuery, FavouriteQuery>().ReverseMap();

        CreateMap<FavouriteEntity, Favourite>().ReverseMap();
    }
}