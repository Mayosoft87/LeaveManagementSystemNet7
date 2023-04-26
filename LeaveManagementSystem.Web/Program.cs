using LeaveManagementSystem.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LeaveManagementSystem.Web.Configurations;
using LeaveManagementSystem.Web.Contracts;
using LeaveManagementSystem.Web.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using LeaveManagementSystem.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Get the Database string connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Default ASPNET UserConnections
builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddTransient<IEmailSender>(s => new EmailSender("LFVMAIL1", 25, "noreply@leavemanagement.com"));

//Register the Generic Repository
//AddScoped --The connection will be On for the tiem that the user uses
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//Register the ILeaveTypeRepository
builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

//Create the Automapper Config
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
