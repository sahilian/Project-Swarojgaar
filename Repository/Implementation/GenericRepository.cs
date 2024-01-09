using Microsoft.EntityFrameworkCore;
using Swarojgaar.Data;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;

namespace Swarojgaar.Repository.Implementation;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public List<T> GetAll()
    {
        List<T> entities = _dbSet.ToList();
        return entities;
    }

    public T GetDetails(int id)
    {
        T entity = _dbSet.Find(id)!;
        return entity;
    }

    public bool Create(T entity)
    {
        _dbSet.Add(entity);
        int affectedRows = _context.SaveChanges();
        return affectedRows > 0;
    }

    public bool Edit(T entity)
    {
        _dbSet.Update(entity);
        int affectedRows = _context.SaveChanges();
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        T entity = _dbSet.Find(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                int affectedRows = _context.SaveChanges();
                return affectedRows > 0;
            }

            return false;
    }
}