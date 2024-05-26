namespace FoodGramBackend.BLL.Abstract;

public interface IService<T> where T : class
{
    public List<T> GetAll();
}