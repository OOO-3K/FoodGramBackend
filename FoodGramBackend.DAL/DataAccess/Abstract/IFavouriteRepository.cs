using FoodGramBackend.DAL.Entities;
using FoodGramBackend.DAL.Models;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IFavouriteRepository : IRepository<FavouriteEntity>
{
    public List<FavouriteEntity> GetByQuery(FavouriteDbQuery favouriteDbQuery);
}