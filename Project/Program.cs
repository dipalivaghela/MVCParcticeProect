
using BAL.Service;
using DAL.DBContext;
using DAL.GenericInterface;
using DAL.GenericRepo;
using IOCcontainer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

DependencyInjection.RegisterServices(builder.Services);

builder.Services.AddDbContext<DBContextClass>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalManagementConnectionString")));

//builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "patient",
        pattern: "{controller=Patients}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "bulkInsert",
      pattern: "Doctor/Index",
      defaults: new { controller = "Doctor", action = "Index" }
  );

    endpoints.MapControllerRoute(
name: "DoctorPatient",
        pattern: "{controller=Dropdown}/{action=Index}/{id?}"
        );
});

app.Run();
