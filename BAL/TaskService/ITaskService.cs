using Domain.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.TaskService
{
    public interface ITaskService
    {
       // IEnumerable<TaskDto> GetAllTask(TaskStatus status);
        Task<IEnumerable<TaskDto>> GetAllTask();
        Task<TaskDto> GetTaskById(int id);
        Task AddTask(TaskDto task);
        Task UpdateTask(TaskDto task);
        Task DeleteTask(int id);
        //Task<IEnumerable<TaskDto>> SearchPatientsByName(string name);
    }
}
