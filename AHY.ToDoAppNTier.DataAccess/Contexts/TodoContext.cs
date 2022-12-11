using AHY.ToDoAppNTier.DataAccess.Configurations;
using AHY.ToDoAppNTier.Entities.Domains;
using Microsoft.EntityFrameworkCore;

namespace AHY.ToDoAppNTier.DataAccess.Contexts
{
    public class TodoContext :DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
        }

        public DbSet<Work> Works { get; set; }
    }
}
