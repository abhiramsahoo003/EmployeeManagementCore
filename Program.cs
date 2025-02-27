using EmployeeManagementCore.Middleware;
using EmployeeManagementCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

// used to initialize and configure an ASP.NET Core web application using the Minimal Hosting Model.
var builder = WebApplication.CreateBuilder(args);

// Add services or Register services to the container.
builder.Services.AddControllersWithViews();

// address dbcontext to the container.
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();

// Build the application (finalizes the configuration)
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root
    });
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Register Middleware
app.UseMiddleware<RequestTimingMiddleware>(); 

app.Run();
