namespace FoodGramBackend.BLL.Services;

public interface IService<T> where T : class
{
    public IEnumerable<T> GetAll();
}