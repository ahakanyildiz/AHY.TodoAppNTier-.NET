using AHY.ToDoAppNTier.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AHY.ToDoAppNTier.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();

        Task<T> Find(object id);

        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);

        Task Create(T entity);

        void Update(T entity,T unChanged);

        void Remove(T entity);
    }
}
