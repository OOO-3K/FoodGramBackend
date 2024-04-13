using AutoMapper;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.DataAccess;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.BLL.Services;

public class RecipeService : IService<Recipe>
{
    private readonly IRepository<RecipeEntity> _repository;
    private readonly IMapper _mapper;

    public RecipeService(IMapper mapper, IRepository<RecipeEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public IEnumerable<Recipe> GetAll()
    {
        var recipes = _repository.GetAll();
        return _mapper.Map<List<RecipeEntity>, List<Recipe>>(recipes.ToList());
    }
}