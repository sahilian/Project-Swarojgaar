namespace Swarojgaar.Repository.Interface;

public interface IGenericRepository<T> where T : class
{
    List<T> GetAll();
    T GetDetails(int id);
    bool Create(T entity);
    bool Edit(T entity);
    bool Delete(int id);
}