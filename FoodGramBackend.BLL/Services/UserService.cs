using AutoMapper;
using FoodGramBackend.BLL.Abstract;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.BLL.Services;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> _repository;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IRepository<UserEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public IEnumerable<User> GetAll()
    {
        var users = _repository.GetAll();
        return _mapper.Map<List<UserEntity>,List<User>>(users.ToList());
    }
}