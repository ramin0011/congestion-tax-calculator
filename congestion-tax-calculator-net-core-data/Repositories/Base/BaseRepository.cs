using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using congestion_tax_calculator_net_core_data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace congestion_tax_calculator_net_core_data.Repositories.Base
{
    public class BaseRepository<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected readonly CongestionDbContext _context;
        public BaseRepository(CongestionDbContext context)
        {
            _context = context;
        }

        public Task<int> Count(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).CountAsync();
        }

        public ValueTask<EntityEntry<T>> Add(T entity)
        {
           return _context.Set<T>().AddAsync(entity);
        }

        public Task AddRange(IEnumerable<T> entities)
        {
           return _context.Set<T>().AddRangeAsync(entities);
        }



        public Task<List<T>> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToListAsync();
        }

        public Task<List<T>> GetAll()
        {
            return _context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public ValueTask<T> GetById(int id)
        {
            return _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async void Dispose()
        {
            await _context?.SaveChangesAsync()!;
        }


    }
}
