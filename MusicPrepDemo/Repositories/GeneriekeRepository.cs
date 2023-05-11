using Microsoft.EntityFrameworkCore;
using MusicPrepDemo.Context;
using MusicPrepDemo.Models;

namespace MusicPrepDemo.Repositories {
  public class GeneriekeRepository<T> where T : Entiteit {
    private readonly DataContext _context;
    private readonly DbSet<T> _table;
    public GeneriekeRepository(DataContext context) {
      _context = context;
      _table = context.Set<T>();
    }

    public async Task Add(T entity) {
      _table.AddAsync(entity);
    }

    public void Delete(T entity) {
      _table.Remove(entity);
    }

    public async Task<IEnumerable<T>?> GetAll() {
      return await _table.ToListAsync();
    }

    public async Task<T?> GetById(int id) {
      return await _table.FindAsync(id);
    }

    public async Task SaveChangesAsync() {
      await _context.SaveChangesAsync();
    }

    public void Update(T entity) {
      _table.Update(entity);
    }

    public async Task<T?> Find(Func<T, bool> predicate) {
      return _table.FirstOrDefault(predicate);
    }
  }
}
