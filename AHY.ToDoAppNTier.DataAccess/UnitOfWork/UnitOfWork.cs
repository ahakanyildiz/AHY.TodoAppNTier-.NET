using AHY.ToDoAppNTier.DataAccess.Abstract;
using AHY.ToDoAppNTier.DataAccess.Concrete;
using AHY.ToDoAppNTier.DataAccess.Contexts;
using AHY.ToDoAppNTier.Entities.Domains;
using System.Threading.Tasks;

namespace AHY.ToDoAppNTier.DataAccess.UnitOfWork 
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;

        public UnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
