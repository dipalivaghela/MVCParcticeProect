using DAL.DoctorRepo;
using Domain.Model;
using Domain.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Domain.Enums;

namespace BAL.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepository;

        public DoctorService(IDoctorRepo doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _doctorRepository.GetAllDoctorsAsync();
        }

        public void ImportDataFromExcel(Stream excelStream)
        {   
            using (var workbook = new XLWorkbook(excelStream))
            {
                var worksheet = workbook.Worksheet(1); 

                var rows = worksheet.RowsUsed().Skip(1); 

                foreach (var row in rows)
                {
                    var cellValues = row.Cells().Select(c => c.Value.ToString()).ToList();

                    var newData = new Doctor
                    {
                        Name = cellValues[0],
                        Gender = (Gender)Enum.Parse(typeof(Gender), cellValues[1]),
                        Specialization = cellValues[2],
                        Experience = cellValues[3],
                        ContactNo = cellValues[4],
                        EmailId = cellValues[5],
                        Schedule = cellValues[6],
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    _doctorRepository.InsertExcel(newData);
                }
            }
        }      
    }
}
