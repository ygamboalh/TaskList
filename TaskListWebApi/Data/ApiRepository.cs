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
        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync()>0;
        }
    }
}
