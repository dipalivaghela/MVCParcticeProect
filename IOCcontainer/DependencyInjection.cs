using BAL.DoctorService;
using BAL.Service;
using DAL.DBContext;
using DAL.DoctorRepo;
using DAL.GenericInterface;
using DAL.GenericRepo;
using DAL.Interface;
using DAL.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace IOCcontainer
{
    public static class DependencyInjection
    {
       public static void RegisterServices(IServiceCollection services)
       {
          services.AddScoped<IPatientRepo, PatientRepo>();
          services.AddScoped<IPatientService, PatientService>();

            services.AddScoped<IDoctorRepo,DoctorRepo>();
            services.AddScoped<IDoctorService,DoctorService>();
        }
    }
}