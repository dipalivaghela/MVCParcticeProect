using Domain.Model;
using Domain.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DoctorService
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        //Task BulkInsertDoctors(List<DoctorDto> doctors);
      //  Task BulkInsert(List<DoctorDto> doctors);
        void ImportDataFromExcel(Stream excelStream);
    }
}
