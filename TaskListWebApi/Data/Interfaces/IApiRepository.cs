using TaskListWebApi.Models;

namespace TaskListWebApi.Data.Interfaces
{
    public interface IApiRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<TaskList>> GetTaskListsAsync();
        Task<TaskList> GetTaskListById(int id);
    }
}
