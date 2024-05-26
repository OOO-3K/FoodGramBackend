using FoodGramBackend.DAL.DataAccess.Abstract;
using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodGramBackend.DAL.DataAccess.Repositories;

public class FavouriteRepository : IFavouriteRepository
{
    private readonly FoodGramDbContext _context;

    public FavouriteRepository(FoodGramDbContext context)
    {
        _context = context;
    }

    public List<FavouriteEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<FavouriteEntity> GetByQuery(FavouriteDbQuery favouriteDbQuery)
    {
        var dbQuery = _context.Favourites.AsQueryable();

        dbQuery.Where(x => x.UserId == favouriteDbQuery.UserId);

        if (favouriteDbQuery.RecipeId.HasValue)
        {
            dbQuery.Where(x => x.RecipeId == favouriteDbQuery.RecipeId);
        }

        return dbQuery.ToList();
    }

    public void Save(FavouriteEntity entity)
    {
        if (GetByQuery(new FavouriteDbQuery { UserId = entity.UserId, RecipeId = entity.RecipeId }).Count > 0)
        {
            return;
        }

        _context.Favourites.Add(entity);
        _context.SaveChanges();
    }

    public void Update(FavouriteEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(FavouriteEntity entity)
    {
        var favourite = GetByQuery(new FavouriteDbQuery { UserId = entity.UserId, RecipeId = entity.RecipeId });

        if (favourite.Count == 1)
        {
            _context.Favourites.Remove(favourite[0]);
            _context.SaveChanges();
        }
    }
}