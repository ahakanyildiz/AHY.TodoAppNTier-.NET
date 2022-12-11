using AHY.ToDoAppNTier.DataAccess.Abstract;
using AHY.ToDoAppNTier.DataAccess.Contexts;
using AHY.ToDoAppNTier.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AHY.ToDoAppNTier.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _context;

        public GenericRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync() : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> Find(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity,T unChanged)
        {
            //id => entity entity.property =
            // Property bazında Update işlemi için CurrentValues kullandım.
           
            _context.Entry(unChanged).CurrentValues.SetValues(entity);
            //_context.Set<T>().Update(Entity);
        }
    }
}
