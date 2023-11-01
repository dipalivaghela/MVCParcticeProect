using Domain.Model.Dtos;
using Domain.Model;
using DAL.TaskRepo;

namespace BAL.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo _taskRepo;

        public TaskService(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTask()
        {
            var task = await _taskRepo.GetAllTasksAsync();

            var patientDtos = task.Select(p => new TaskDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                DueDate = (DateTime)p.DueDate,
                Status = (Domain.Model.Dtos.TaskStatus)p.Status,
            });
            return patientDtos;
        }


        public async Task<TaskDto> GetTaskById(int id)
        {
            var task = await _taskRepo.GetTasksByIdAsync(id);
            if (task == null)
            {
                return null;
            }

            var taskViewModel = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = (DateTime)task.DueDate,
                Status = (Domain.Model.Dtos.TaskStatus)task.Status,
            };

            return taskViewModel;
        }


        public async Task AddTask(TaskDto task)
        {
            var taskModel = new Tasks
            {
                // Id = (int)patient.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = (DateTime)task.DueDate,
                Status = (Domain.Model.TaskStatus)task.Status, 

            };

            await _taskRepo.AddTasksAsync(taskModel);
        }

        public async Task UpdateTask(TaskDto task)
        {
            var taskModel = await _taskRepo.GetTasksByIdAsync((int)task.Id);

            if (taskModel == null)
                throw new Exception("Task not found.");

            taskModel.Id = (int)task.Id;
            taskModel.Title = task.Title;
            taskModel.Description = task.Description;
            taskModel.DueDate = task.DueDate;
            taskModel.Status = (Domain.Model.TaskStatus)task.Status;

            await _taskRepo.UpdateTasksAsync(taskModel);
        }

        public async Task DeleteTask(int id)
        {
            var task = await _taskRepo.GetTasksByIdAsync(id);

            if (task == null)
                throw new Exception("Task not found.");

            await _taskRepo.DeleteTasksAsync(task);
        }

        /*public async Task<IEnumerable<TaskDto>> SearchPatientsByName(string name)
        {
            var patients = await _patientRepo.SearchPatientsByNameAsync(name);

            var patientViewModels = patients.Select(p => new PatientDto
            {
                Id = p.Id,
                Name = p.Name,
                Gender = p.Gender,
                DateOfBirth = (DateTime)p.DateOfBirth,
                DoctorId = p.DoctorId
            });

            return patientViewModels;
        }
        public async Task<IEnumerable<Patient>> GetPatientsByDoctorId(int doctorId)
        {
            return await _patientRepo.GetPatientsByDoctorIdAsync(doctorId);
        }*/
        /*public async Task<IEnumerable<PatientDto>> GetPatientsByDoctorId(int doctorId)
        {
            var patients = await _patientRepo.GetPatientsByDoctorId(doctorId);

            return patients.Select(p => new PatientDto
            {
                Id = p.Id,
                Name = p.Name,
                Gender = p.Gender,
                DateOfBirth = (DateTime)p.DateOfBirth,
                DoctorId = p.DoctorId
            });
        }*/

    }
}

