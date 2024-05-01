using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.DataContext;
using FoodGramBackend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodGramBackend.DAL.DataAccess.Repositories;

public class UserRepository : IRepository<UserEntity>
{
    private readonly FoodGramDbContext _context;

    public UserRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public IEnumerable<UserEntity> GetAll()
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