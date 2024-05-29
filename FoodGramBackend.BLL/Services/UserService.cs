using AutoMapper;
using FoodGramBackend.BLL.Abstract;
using FoodGramBackend.BLL.Models;
using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IUserRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public User GetByQuery(UserQuery userQuery)
    {
        var user = _repository.GetByName(userQuery.Name);

        if (user == null)
        {
            return null;
        }

        if (!VerifyPassword(userQuery.Password, user.PasswordHash))
        {
            return null;
        }

        return _mapper.Map<User>(user);
    }

    public List<User> GetAll()
    {
        throw new NotImplementedException();
    }

    private bool VerifyPassword(string queryPassword, string dbPassword)
    {
        //TODO: change logic for hash check
        return queryPassword == dbPassword;
    }
}