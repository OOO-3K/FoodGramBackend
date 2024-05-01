using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();

    void Update(T entity);

    void Save(T entity);
}