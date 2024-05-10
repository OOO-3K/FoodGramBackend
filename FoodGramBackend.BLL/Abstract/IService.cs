namespace FoodGramBackend.BLL.Abstract;

public interface IService<T> where T : class
{
    public IEnumerable<T> GetAll();
}