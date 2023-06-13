using DAL.DBContext;
using DAL.GenericInterface;
using DAL.GenericRepo;
using DAL.Interface;
using Domain.Model;
using Domain.Model.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{

        public class PatientRepo : GenericRepo<Patient>, IPatientRepo
        {
            private readonly DBContextClass _dbContext;
            public PatientRepo(DBContextClass context) : base(context)
            {
                   _dbContext = context;
            }

            public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
            {
                   return await GetAllAsync();
        }

            public async Task<Patient> GetPatientByIdAsync(int id)
            {
                return await GetByIdAsync(id);
            }

            public async Task  AddPatientAsync(Patient patients)
            {
               await AddAsync(patients);
            }

            public async Task UpdatePatientAsync(Patient patient)
            {
                await UpdateAsync(patient);
            }

            public async Task DeletePatientAsync(Patient patient)
            {
               await DeleteAsync(patient);
            }

        /* public async Task<IEnumerable<Patient>> SearchPatientsAsync(string searchQuery)
         {
             var patient = await _dbContext.Patients
               .FromSqlRaw("EXECUTE GetPatientsByName @Name = {0}", searchQuery)
               .ToListAsync();

             return patient;*/

        /*return await _dbContext.Patients
            .Where(p => p.Name.Contains(searchQuery))
            .ToListAsync();}*/

        /*public IEnumerable<Patient> GetPatientsByName(string name)
        {
            return _dbContext.Patients
                .FromSqlRaw("EXECUTE GetPatientsByName @Name", new SqlParameter("Name", name))
                .ToList();
        }*/
    }
}


