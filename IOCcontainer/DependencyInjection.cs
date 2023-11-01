using BAL.TaskService;
using DAL.TaskRepo;
using Microsoft.Extensions.DependencyInjection;

namespace IOCcontainer
{
    public static class DependencyInjection
    {
       public static void RegisterServices(this IServiceCollection services)
       {

            services.AddScoped<ITaskRepo,TaskRepo>();
            services.AddScoped<ITaskService,TaskService>();
        }
    }
}