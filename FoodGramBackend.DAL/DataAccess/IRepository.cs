namespace FoodGramBackend.DAL.DataAccess;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
}