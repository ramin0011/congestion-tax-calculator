using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace congestion_tax_calculator_net_core_data.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        ValueTask<T> GetById(int id);
        IQueryable<T> GetAllQueryable();
        Task<List<T>> GetAll();
        Task<List<T>> Find(Expression<Func<T, bool>> expression);
        Task<int> Count(Expression<Func<T, bool>> expression);
        ValueTask<EntityEntry<T>> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Remove(T entity);
    }
}
