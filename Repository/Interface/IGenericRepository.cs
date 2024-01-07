namespace Swarojgaar.Repository.Interface;

public interface IGenericRepository<T> where T : class
{
    List<T> GetAll();
    T GetDetails(int id);
    void Create(T entity);
    void Edit(T entity);
    void Delete(int id);
}