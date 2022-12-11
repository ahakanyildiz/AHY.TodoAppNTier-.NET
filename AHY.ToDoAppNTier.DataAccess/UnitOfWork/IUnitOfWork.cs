using AHY.ToDoAppNTier.DataAccess.Abstract;
using AHY.ToDoAppNTier.Entities.Domains;
using System.Threading.Tasks;

namespace AHY.ToDoAppNTier.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChanges();
    }
}
