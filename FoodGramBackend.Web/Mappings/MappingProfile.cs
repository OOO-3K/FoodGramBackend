using AutoMapper;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.Web.Models;

namespace FoodGramBackend.Web.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RecipeQuery, RecipeQueryEm>().ReverseMap();
    }
}