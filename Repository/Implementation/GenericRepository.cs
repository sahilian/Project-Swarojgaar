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

    public void Create(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Edit(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        T job = _dbSet.Find(id)!;
        _dbSet.Remove(job);
        _context.SaveChanges();
    }
}