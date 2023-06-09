using BAL.Interface;
using BAL.Service;
using DAL.DBContext;
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


            
        }
    }
}