using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace congestion_tax_calculator_net_core_data.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAllQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
    }
}
