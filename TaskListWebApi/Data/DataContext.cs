using Microsoft.EntityFrameworkCore;
using TaskListWebApi.Models;

namespace TaskListWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DataContext()
        {

        }
        public DbSet<TaskList> TaskLists { get; set; }
    }
}
