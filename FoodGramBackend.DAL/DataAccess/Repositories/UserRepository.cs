using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodGramBackend.DAL.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FoodGramDbContext _context;

    public UserRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public UserEntity GetById(Guid id)
    {
        return _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public List<UserEntity> GetAll()
    {
        return _context.Users.ToList();
    }

    public void Save(UserEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(UserEntity entity)
    {
        throw new NotImplementedException();
    }
}