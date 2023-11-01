using DAL.DBContext;
using DAL.GenericInterface;
using DAL.GenericRepo;
using IOCcontainer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

DependencyInjection.RegisterServices(builder.Services);

builder.Services.AddDbContext<DBContextClass>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("TaskManagerConnectionString")));

//builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/registration/register"; // This sets the login path to the registration page.
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtOptions =>
{
    jwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "your_issuer",
        ValidAudience = "your_audience",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_security_key"))
    };
});


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
        name: "User",
        pattern: "user/{action=Register}/{id?}",
        defaults: new { controller = "Registration" }
    );

    endpoints.MapControllerRoute(
        name: "Task",
        pattern: "tasks/{action=Index}/{id?}",
        defaults: new { controller = "Tasks" }
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Registration}/{action=register}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "dashboard",
    pattern: "Dashboard/Index",
    defaults: new { controller = "Dashboard", action = "Index" }
);

    endpoints.MapControllerRoute(
        name: "UserProfile",
        pattern: "UserProfile/Index",
        defaults: new { controller = "UserProfile", action = "Index" }
    );


});



app.Run();
