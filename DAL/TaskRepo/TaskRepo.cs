using DAL.DBContext;
using DAL.GenericRepo;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TaskRepo
{
    public class TaskRepo : GenericRepo<Tasks>, ITaskRepo
    {
        private readonly DBContextClass _dbContext;
        public TaskRepo(DBContextClass context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Tasks> GetTasksByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task AddTasksAsync(Tasks task)
        {
            await AddAsync(task);
        }

        public async Task UpdateTasksAsync(Tasks task)
        {
            await UpdateAsync(task);
        }

        public async Task DeleteTasksAsync(Tasks task)
        {
            await DeleteAsync(task);
        }

        /*public async Task<IEnumerable<Tasks>> SearchTasksByNameAsync(string name)
        {
            var parameters = new SqlParameter("Name", name);

            return await _dbContext.Patients.FromSqlRaw("EXECUTE SearchPatients @Name", parameters).ToListAsync();
        }*/
    }
}

