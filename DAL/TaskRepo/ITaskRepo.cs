using DAL.GenericInterface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TaskRepo
{
    public interface ITaskRepo : IGenericRepo<Tasks>
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTasksByIdAsync(int id);
        Task AddTasksAsync(Tasks task);
        Task UpdateTasksAsync(Tasks task);
        Task DeleteTasksAsync(Tasks task);
        //Task<IEnumerable<Tasks>> SearchTasksByNameAsync(string name);
    }
}
