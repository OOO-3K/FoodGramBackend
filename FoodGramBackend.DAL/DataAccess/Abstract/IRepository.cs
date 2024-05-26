using FoodGramBackend.DAL.Entities;

namespace FoodGramBackend.DAL.DataAccess.Abstract;

public interface IRepository<T> where T : class
{
    List<T> GetAll();

    void Update(T entity);

    void Save(T entity);

    void Delete(T entity);
}