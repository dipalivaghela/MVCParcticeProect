using DAL.GenericInterface;
using Domain.Model;
using Domain.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DoctorRepo
{
    public interface IDoctorRepo :IGenericRepo<Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        void InsertExcel(Doctor newData);
    }
}
