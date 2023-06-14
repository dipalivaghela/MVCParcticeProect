using DAL.DoctorRepo;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
