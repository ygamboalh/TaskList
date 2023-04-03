using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListWebApi.Models;

namespace TaskListTests.Fixtures
{
    public static class TaskFixtures
    {

        public static bool Eliminar (int id) 
        {
            List<TaskList> tasks = GetTasklists();
            tasks.RemoveAt(0);
            return true;
        }
       public static List<TaskList> GetTasklists() =>

            new()
            {
                new TaskList()
                {
                    Id = 1,
                    Description = "Description",
                    Status = true
                },
                new TaskList()
                {
                    Id = 2,
                    Description = "Description2",
                    Status = true
                },
                new TaskList()
                {
                    Id = 3,
                    Description = "Description3",
                    Status = true
                },
                new TaskList()
                {
                    Id = 4,
                    Description = "Description4",
                    Status = true
                },

            };
        
    }
}
