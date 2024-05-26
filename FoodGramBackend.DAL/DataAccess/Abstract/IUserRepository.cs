using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IUserRepository
{
    public UserEntity GetById(Guid id);
}