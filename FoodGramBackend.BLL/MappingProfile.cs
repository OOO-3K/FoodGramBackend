using AutoMapper;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, User>()
            .ForMember(u => u.Id, opt => opt.MapFrom(ue => ue.Id))
            .ForMember(u => u.Name, opt => opt.MapFrom(ue => ue.Name))
            .ForMember(u => u.PasswordHash, opt => opt.MapFrom(ue => ue.PasswordHash));
        CreateMap<RecipeEntity, Recipe>()
            .ForMember(r => r.Id, opt => opt.MapFrom(re => re.Id))
            .ForMember(r => r.Name, opt => opt.MapFrom(re => re.Name))
            .ForMember(r => r.Description, opt => opt.MapFrom(re => re.Description))
            .ForMember(r => r.ImagePath, opt => opt.MapFrom(re => re.ImagePath))
            .ForMember(r => r.CookingTime, opt => opt.MapFrom(re => re.CookingTime))
            .ForMember(r => r.Rating, opt => opt.MapFrom(re => re.Rating));
    }
}