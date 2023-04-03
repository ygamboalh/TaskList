using Microsoft.EntityFrameworkCore;
using TaskListWebApi.Data.Interfaces;
using TaskListWebApi.Models;

namespace TaskListWebApi.Data
{
    public class ApiRepository : IApiRepository
    {
        private readonly DataContext _dataContext;

        public ApiRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public async Task<TaskList> GetTaskListById(int id)
        {
            var taskList = await _dataContext.TaskLists.FirstOrDefaultAsync(t => t.Id == id);
            return taskList;
        }

        public async Task<IEnumerable<TaskList>> GetTaskListsAsync()
        {
            var taskList = await _dataContext.TaskLists.ToListAsync();
            return (IEnumerable<TaskList>)taskList;
        }

        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync()>0;
        }
    }
}
