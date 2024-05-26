using FoodGramBackend.BLL.Models;

namespace FoodGramBackend.BLL.Abstract;

public interface IUserService : IService<User>
{
    public User GetByQuery(UserQuery userQuery);
}