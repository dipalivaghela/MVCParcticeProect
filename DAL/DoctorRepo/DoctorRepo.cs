using DAL.DBContext;
using DAL.GenericInterface;
using DAL.GenericRepo;
using Domain.Model;
using Domain.Model.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DoctorRepo
{
    public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
    {
        private readonly DBContextClass _dBContext;
        public DoctorRepo(DBContextClass dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await GetAllAsync();
        }

        public void InsertExcel(Doctor customer)
        {
            _dBContext.Doctors.Add(customer);
            _dBContext.SaveChanges();
        }
    }

}

